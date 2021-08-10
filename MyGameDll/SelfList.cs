using MyGameDll.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGameDll
{
    public delegate void AddTeam_Event();
    public delegate void RemoveTeam_Event();
    public delegate void TeamCountChange_Event();

    public class TeamList : List<GameObject>
    {
        public AddTeam_Event addTeam_Event;
        public RemoveTeam_Event removeTeam_Event;
        public TeamCountChange_Event teamCountChange_Event;

        private bool _isRemoveCampType = false;

        public new void Add(GameObject item)
        {
            AbstractTeam teamShard = item.GetComponent<AbstractTeam>();
            if(teamShard != null)
            {
                base.Add(item);
                if (HaveDifferentCamp())
                {
                    addTeam_Event();
                }
                teamCountChange_Event();
            }
        }

        public new void Remove(GameObject item)
        {
            base.Remove(item);
            if (!HaveDifferentCamp())
            {
                removeTeam_Event();
            }
            if (!_isRemoveCampType)
            {
                teamCountChange_Event();
            }
        }

        public List<GameObject> Remove(CampEnum CampType)
        {
            _isRemoveCampType = true;
            List<GameObject> list = new List<GameObject>();
            foreach(GameObject go in this)
            {
                if(go.GetComponent<AbstractTeam>().Camp == CampType)
                {
                    list.Add(go);
                }
            }

            foreach(GameObject go in list)
            {
                Remove(go);
            }
            _isRemoveCampType = false;
            teamCountChange_Event();
            return list;
        }

        public bool HaveDifferentCamp()
        {

            if (Count > 1)
            {
                GameObject go1 = this[0];
                for(int i = 1;i<Count; i++)
                {
                    if(go1.GetComponent<AbstractTeam>().Camp != this[i].GetComponent<AbstractTeam>().Camp)
                    {
                        return true;
                    }
                }
                

            }

            return false;
        }
    }
}