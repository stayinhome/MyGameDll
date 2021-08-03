using UnityEngine;


namespace MyGameDll.Model.Building
{
    public class Trap : MonoBehaviour
    {
        public CampEnum BelongCamp = CampEnum.None;

        public int Damage = 0;

        /// <summary>
        /// 部署需要的资源
        /// </summary>
        public int NeedMaterial = 0;
    }
}