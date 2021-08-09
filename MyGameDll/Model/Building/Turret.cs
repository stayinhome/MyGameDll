using MyGameDll.Abstract;
using MyGameDll.Interface;
using MyGameDll.Model.Abstract;
using UnityEngine;

namespace MyGameDll.Model.Building
{
    public class Turret : AbstractBuilding, ISupport
    {
        public GameObject Target { get ; set; }

        public int MinSupportRang
        {

            get
            {
                return 0;
            }

            set
            {

                MinSupportRang = value;
            }
        }

        private int _MaxSupportRang = 5;

        public int MaxSupportRang
        {
            get
            {
                return _MaxSupportRang;
            }
            set
            {
                _MaxSupportRang = value;
            }
        }


        private GameObject _SupportNode = null;

        public GameObject SupportNode
        { 
            get
            {
                return _SupportNode;
            }
            set
            {
                _SupportNode?.GetComponent<AbstractNode>().FireSupport.Remove(this.gameObject);

                _SupportNode = value;

                _SupportNode?.GetComponent<AbstractNode>().FireSupport.Add(this.gameObject);
            }
        }

        public bool IsWasSupport { get; set; } = false;

        public int FireSupport
        {
            get
            {
                return 10;
            }
        }

        public CampEnum BelongCamp
        {
            get { return Camp; }
            set { Camp = value; }
        }

        /// <summary>
        /// 部署需要的资源
        /// </summary>
        public int NeedMaterial = 0;

        void Start()
        {
            Target = gameObject.transform.Find("Target").gameObject;
        }

        public void RefreshMe()
        {
            IsWasSupport = false;
        }

    }
}