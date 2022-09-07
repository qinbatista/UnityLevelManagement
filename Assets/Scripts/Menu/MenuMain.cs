using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LevelManagement
{
    public class MenuMain : Menu<MenuMain>
    {
        DataManager _dataManager;
        [SerializeField] InputField _inputField;
        protected override void Awake()
        {
            base.Awake();
            _dataManager = FindObjectOfType<DataManager>();
            _inputField = GetComponentInChildren<InputField>();
            _inputField.text = _dataManager.PlayerName;
        }
        void Start()
        {

        }
        void LoadData()
        {
            if (_dataManager != null && _inputField != null)
            {
                _dataManager.Load();
                _inputField.text = _dataManager.PlayerName;
            }
        }
        public void OnPlayerNameValueChanged(string name)
        {
            if (_dataManager != null)
            {
                _dataManager.PlayerName = name;
            }
        }
        public void OnPlayerNameEndEdit()
        {
            if (_dataManager != null)
            {
                _dataManager.Save();
            }
        }
        public void OnPlayPressed()
        {
            // GameManager.Instance.ReloadLevel();
            SampleGame.GameManager.Instance.ReloadLevel();
            if (MenuManager.Instance != null && MenuGame.Instance != null)
            {
                MenuManager.Instance.OpenMenu(MenuGame.Instance);
            }
        }
        public void OnSettingsPressed()
        {
            if (MenuManager.Instance != null && MenuSetting.Instance != null)
            {
                MenuManager.Instance.OpenMenu(MenuSetting.Instance);
            }
        }
        public void OnCreditsPressed()
        {
            if (MenuManager.Instance != null && MenuCredits.Instance != null)
            {
                MenuManager.Instance.OpenMenu(MenuCredits.Instance);
            }
        }
        public override void OnBackPressed()
        {
            // base.OnBackPressed();
            Application.Quit();
        }
    }
}
