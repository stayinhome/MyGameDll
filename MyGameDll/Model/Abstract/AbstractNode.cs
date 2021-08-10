using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll.Abstract
{
    public class AbstractNode : MonoBehaviour
    {

        public int NodeID = 0;

        private GameObject _OtherObject = null;
        /// <summary>
        /// 其他对象
        /// </summary>
        public GameObject OtherObject
        {
            get
            {
                return _OtherObject;
            }
            set
            {
                _OtherObject = value;
                if(value.tag == "Turret")
                {
                    CalGameObjectPosition();
                }
            }
        }
            

        /// <summary>
        /// 类型
        /// </summary>
        public NodeEnum NodeType = NodeEnum.Normol;

        /// <summary>
        /// 所属阵营
        /// </summary>
        public CampEnum Camp = CampEnum.None;

        /// <summary>
        /// 临接节点
        /// </summary>
        public List<GameObject> NextNode = new List<GameObject>();

        /// <summary>
        /// 火力支援
        /// </summary>
        public List<GameObject> FireSupport = new List<GameObject>();

        public int CurTeamCount
        {
            get
            {
                return CurTeam.Count;
            }
        }
        /// <summary>
        /// 当前存在队伍
        /// </summary>
        public TeamList CurTeam = new TeamList();

        public virtual void Start()
        {
            CurTeam.addTeam_Event += AddTeam_Event;
            CurTeam.removeTeam_Event += RemoveTeam_Event;
            CurTeam.teamCountChange_Event += CalGameObjectPosition;
        }

        public void AddTeam_Event()
        {
            GameObject.Find("GlobalObject").GetComponent<GlobalObject>().listNode.Add(gameObject);
        }

        public void RemoveTeam_Event()
        {
            GameObject.Find("GlobalObject").GetComponent<GlobalObject>().listNode.Remove(gameObject);
        }

        public void CalGameObjectPosition()
        {
            if(CurTeam.Count == 0)
            {
                return;
            }

            Vector3 NodePosition = this.gameObject.transform.position;
            bool haveTurret = false;
            if (_OtherObject!= null && _OtherObject.tag == "Turret")
            {
                _OtherObject.transform.position = new Vector3(NodePosition.x, NodePosition.y, _OtherObject.transform.position.z);
                haveTurret = true;
            }
            double anglc = 360 / CurTeam.Count;
            List<GameObject> PlayTeam = new List<GameObject>();
            List<GameObject> EnemyTeam = new List<GameObject>();
            foreach (GameObject team in CurTeam)
            {
                if (team.GetComponent<AbstractTeam>().Camp == CampEnum.Player)
                {
                    PlayTeam.Add(team);
                }
                else if (team.GetComponent<AbstractTeam>().Camp == CampEnum.Enemy)
                {
                    EnemyTeam.Add(team);
                }

            }
            if(PlayTeam.Count != 0 && EnemyTeam.Count != 0)
            {
                bool mark = false;
                int difY = 1;
                foreach(GameObject item in PlayTeam)
                {
                    item.transform.position = new Vector3(NodePosition.x - 1, NodePosition.y + difY, item.transform.position.z);
                    if (mark)
                    {
                        difY = difY + difY/Math.Abs(difY);
                        mark = false;
                    }
                    else
                    {
                        difY = -difY;
                        mark = true;
                    }
                }
                foreach (GameObject item in EnemyTeam)
                {
                    item.transform.position = new Vector3(NodePosition.x + 1, NodePosition.y + difY, item.transform.position.z);
                    if (mark)
                    {
                        difY = difY + difY / Math.Abs(difY);
                        mark = false;
                    }
                    else
                    {
                        difY = -difY;
                        mark = true;
                    }
                }
            }
            else if(PlayTeam.Count != 0 || EnemyTeam.Count != 0)
            {
                List<GameObject> TempTeam = new List<GameObject>(); 
                if (PlayTeam.Count != 0)
                {
                    TempTeam = PlayTeam;
                }
                else
                {
                    TempTeam = EnemyTeam;
                }

                if (haveTurret)
                {
                    int i = 0;
                    foreach (GameObject item in TempTeam)
                    {
                        float difx = (float)Math.Cos(anglc * i);
                        float dify = (float)Math.Sin(anglc * i);
                        item.transform.position = new Vector3(NodePosition.x + difx, NodePosition.y + dify, item.transform.position.z);
                        i++;
                    }
                }
                else
                {
                    if(CurTeam.Count > 1)
                    {
                        anglc = 360 / (CurTeam.Count - 1);
                    }
                    int i = 0;
                    bool isFirst = true;
                    foreach (GameObject item in TempTeam)
                    {
                        float difx = (float)Math.Cos(anglc * i);
                        float dify = (float)Math.Sin(anglc * i);
                        if (isFirst)
                        {
                            item.transform.position = new Vector3(NodePosition.x , NodePosition.y , item.transform.position.z);
                            isFirst = false;
                        }
                        else
                        {
                            item.transform.position = new Vector3(NodePosition.x + difx, NodePosition.y + dify, item.transform.position.z);
                            i++;
                        }

                    }
                }

            }

        }

        /// <summary>
        /// 是否是临接节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool IsNextNode(GameObject node)
        {
            if(node!= null)
            {
                foreach (GameObject item in NextNode)
                {
                    if (item == node)
                    {
                        return true;
                    }
                }
            }


            return false;
        }


    }
}
