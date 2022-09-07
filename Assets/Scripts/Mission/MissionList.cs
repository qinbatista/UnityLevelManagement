using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Mission
{
    [CreateAssetMenu(fileName = "MissionList", menuName = "LevelManagement/Mission/MissionList", order = 1)]
    public class MissionList : ScriptableObject
    {
        #region INSPECTOR
        [SerializeField] List<MissionSpec> _missions;
        #endregion

        #region PROPERTIES
        public int TotalMissions => _missions.Count;
        public MissionSpec GetMission(int index) => _missions[index];
        #endregion
    }
}
