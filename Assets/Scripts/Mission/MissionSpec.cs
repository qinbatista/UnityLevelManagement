using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace LevelManagement.Mission
{
    [Serializable]
    public class MissionSpec
    {
        #region  INSPECTOR
        [SerializeField] private string _name;
        [SerializeField][Multiline] protected string _description;
        [SerializeField] protected string _sceneName;
        [SerializeField] protected int _id;
        [SerializeField] protected Sprite _image;
        #endregion

        #region PROPERTIES
        public string Name => _name;
        public string Description => _description;
        public string SceneName => _sceneName;
        public int Id => _id;
        public Sprite Image => _image;
        #endregion
    }
}
