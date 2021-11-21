using InformationManagement;
using MyGameDll.Abstract;
using MyGameDll.Interface;
using MyGameDll.Model.Building;
using MyGameDll.Model.Dto;
using MyGameDll.MyEventManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameDll
{
    public class AbstractTeam : MonoBehaviour
    {

        public int TeamID = 0;

        /// <summary>
        /// 类型
        /// </summary>
        public TeamEnum TeamType = TeamEnum.None;

        private int _IniBaseNumber = -1;

        public int IniBaseNumber
        {
            get
            {
                if(_IniBaseNumber == -1)
                {
                    int Teamp = 0;
                    foreach(GameObject go in Member)
                    {
                        Teamp += go.GetComponent<AbstractRole>().BaseValue;
                    }
                    _IniBaseNumber = Teamp;
                }

                return _IniBaseNumber;
            }
        }


        private int _BaseNumber = 0;
        /// <summary>
        /// 基础数值
        /// </summary>
        public int BaseNumber
        {

            get
            {
                return _BaseNumber;
            }

            set
            {
                _BaseNumber = value;
                if (_BaseNumber <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    if (gameObject != null)
                    {
                        gameObject.BroadcastMessage("RefreshAttack", Attack);
                        gameObject.BroadcastMessage("RefreshDefent", Defent);
                    }
                }


            }
        }
        /// <summary>
        /// 攻击力
        /// </summary>
        public int Attack
        {
            get
            {
                return CalAttack();
            }

        }
        
        /// <summary>
        /// 防御力
        /// </summary>
        public int Defent
        {
            get
            {
                return CalDefent();
            }

        }



        /// <summary>
        /// 基础行动点
        /// </summary>
        public int BaseOperater = 0;

        public int _Operater = 0;
        /// <summary>
        /// 行动点
        /// </summary>
        public int Operater
        {
            get
            {
                return CalOperater();
            }

            set
            {

                _Operater = value;

                EvenData evenData = new EvenData();
                evenData.Value = value;
                MEventManager.Instance.DispatchEvent(MyEventType.SelectChessOperaterValueChange,gameObject, evenData);
            }
        }

        /// <summary>
        /// 基础视野
        /// </summary>
        public int BaseView = 0;
        /// <summary>
        /// 视野
        /// </summary>
        public int View
        {
            get
            {
                return CalView();
            }

        }

        /// <summary>
        /// 携带物资
        /// </summary>
        public int Material = 0;

        /// <summary>
        /// 最大携带物资
        /// </summary>
        public int MaxMaterial = 0;

        /// <summary>
        /// 当前所在节点
        /// </summary>
        public GameObject CurNode = null;

        /// <summary>
        /// 阵营
        /// </summary>
        public CampEnum Camp = CampEnum.None;



        /// <summary>
        /// 成员
        /// </summary>
        public List<GameObject> Member = new List<GameObject>();

        /// <summary>
        /// 增减益效果
        /// </summary>
        public ArrayList Buffs = new ArrayList();


        public virtual void RefreshMe()
        {
            Operater = BaseOperater;
        }

        public virtual void DoInit(TeamData teamData)
        {
            Camp = teamData.Camp;
            Member = teamData.Member;
            foreach (GameObject item in teamData.Member)
            {
                AbstractRole role = item.GetComponent<AbstractRole>();
                BaseNumber += role.BaseValue;
            }
        }

        /// <summary>
        /// 计算属性
        /// </summary>
        protected virtual void CalProperty()
        {

        }

        /// <summary>
        /// 攻击力计算
        /// </summary>
        /// <returns></returns>
        protected virtual int CalAttack()
        {

            int result = _BaseNumber;
            foreach (var item in Buffs)
            {
                ITeamBuff teamBuff = item as ITeamBuff;
                result = teamBuff.BuffAttack(this.gameObject, result);
            }
            foreach (var item in Buffs)
            {
                ITeamBuff teamBuff = item as ITeamBuff;
                result = teamBuff.BuffFinalAttack(this.gameObject, result);
            }
            return result;
        }

        /// <summary>
        /// 防御力计算
        /// </summary>
        /// <returns></returns>
        protected virtual int CalDefent()
        {
            int result = _BaseNumber;
            foreach (var item in Buffs)
            {
                ITeamBuff teamBuff = item as ITeamBuff;
                result = teamBuff.BuffDefent(this.gameObject, result);
            }
            foreach (var item in Buffs)
            {
                ITeamBuff teamBuff = item as ITeamBuff;
                result = teamBuff.BuffFinalDefent(this.gameObject, result);
            }
            return result;
        }

        /// <summary>
        /// 视野计算
        /// </summary>
        /// <returns></returns>
        protected virtual int CalView()
        {

            int view = BaseView;
            if(CurNode != null && CurNode.GetComponent<AbstractNode>().NodeType == NodeEnum.HighPoints)
            {
                view += PropertyValue.HighPointsAddView;
            }
            foreach (var item in Buffs)
            {
                ITeamBuff teamBuff = item as ITeamBuff;
                view = teamBuff.BuffView(this.gameObject, view);
            }

            return view;

        }

        protected virtual int CalOperater()
        {

            int result = _Operater;
            foreach (var item in Buffs)
            {
                ITeamBuff teamBuff = item as ITeamBuff;
                result = teamBuff.BuffOperater(this.gameObject, result);
            }
            return result;

        }

        public virtual void DoMoveTo(GameObject Node)
        {
            if (!CanMoveTo(Node))
            {
                return ;
            }

            CurNode.GetComponent<AbstractNode>().CurTeam.Remove(gameObject);
            Operater--;

            Vector3 newPosition = new Vector3(Node.transform.position.x, Node.transform.position.y, gameObject.transform.position.z);
            gameObject.GetComponent<MoveScript>().MoveToTarget(newPosition);

            Node.GetComponent<AbstractNode>().CurTeam.Add(gameObject);
            CurNode = Node;

            AfterMove();

        }

        public virtual bool CanMoveTo(GameObject Node)
        {

            if (Operater <= 0)
            {
                return false;
            }

            if (CurNode.GetComponent<AbstractNode>().CurTeam.HaveDifferentCamp())
            {
                return false;
            }

            if (!Node.GetComponent<AbstractNode>().IsNextNode(CurNode))
            {
                return false;
            }

            if (gameObject.GetComponent<MoveScript>().Moveing)
            {
                return false;
            }



            return true;
        }


        void OnDestroy()
        {
            if(CurNode != null)
            {
                AbstractNode abstractNode = CurNode.GetComponent<AbstractNode>();
                if(abstractNode != null)
                {
                    try
                    {
                        abstractNode.CurTeam.Remove(this.gameObject);
                    }
                    catch (Exception e)
                    {
                        Debug.Log("移除对象异常：" + e.ToString());
                    }
                }
            }
        }

        public virtual void AfterMove()
        {
            //if(CurNode!= null)
            //{
            //    AbstractNode NodeProperty = CurNode.GetComponent<AbstractNode>();
            //    if(NodeProperty.OtherObject != null)
            //    {
            //        BuildEnum buildEnum = (BuildEnum)System.Enum.Parse(typeof(BuildEnum), NodeProperty.OtherObject.tag);
            //        switch (buildEnum)
            //        {
            //            case BuildEnum.Roadblock:
            //                {
            //                    Roadblocks roadblocks = NodeProperty.OtherObject.GetComponent<Roadblocks>();
            //                    if (roadblocks.Camp != Camp)
            //                    {
            //                        Operater = 0;
            //                        Destroy(NodeProperty.OtherObject);
            //                        NodeProperty.OtherObject = null;
            //                    }
            //                    break;
            //                }
            //        }

            //    }
            //}

        }
    }
}
