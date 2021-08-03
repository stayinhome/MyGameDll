
using UnityEngine;


namespace MyGameDll.Model.Building
{
    public class Roadblocks : AbstractBuilding
    {
        public CampEnum BelongCamp = CampEnum.None;

        /// <summary>
        /// 部署需要的资源
        /// </summary>
        public int NeedMaterial = 0;

    }
}