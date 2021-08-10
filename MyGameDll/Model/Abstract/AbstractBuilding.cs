using UnityEngine;

namespace MyGameDll.Model.Abstract
{
    public class AbstractBuilding : MonoBehaviour
    {
        public GameObject CurNode = null;

        public CampEnum Camp = CampEnum.None;


        /// <summary>
        /// 部署需要的资源
        /// </summary>
        public int NeedMaterial = 0;

    }
}
