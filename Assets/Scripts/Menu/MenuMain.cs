using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class MenuMain : Menu<MenuMain>
    {
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
