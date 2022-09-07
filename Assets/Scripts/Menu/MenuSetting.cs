using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class MenuSetting : Menu<MenuSetting>
    {
        private DataManager _dataManager;
        protected override void Awake()
        {
            base.Awake();
            _dataManager = Object.FindObjectOfType<DataManager>();
            LoadData();
        }

        public void OnMasterVolumeChanged(float value)
        {
            // Debug.Log("Master volume = "+value);
            _dataManager.MasterVolume = value;
        }
        public void OnSFXChanged(float value)
        {
            // Debug.Log("SFX volume = "+value);
            _dataManager.SfxVolume = value;
        }
        public void OnMusicChanged(float value)
        {
            // Debug.Log("Music volume = "+value);
            _dataManager.MusicVolume = value;
        }
        public void LoadDefaults()
        {

        }
        public override void OnBackPressed()
        {
            base.OnBackPressed();
            if (_dataManager != null)
            {
                _dataManager.Save();
            }

        }
        public void LoadData()
        {
            _dataManager.Load();
        }
    }
}
