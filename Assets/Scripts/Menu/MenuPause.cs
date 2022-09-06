using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class MenuPause : Menu<MenuPause>
    {
        [SerializeField] int mainMenuIndex = 0;
        public void OnResumePressed()
        {
            Time.timeScale = 0;
            base.OnBackPressed();
        }
        public void OnRestartPressed()
        {
            Time.timeScale = 1;
            SampleGame.GameManager.Instance.ReloadLevel();
            base.OnBackPressed();
        }
        public void OnMainMenuPressed()
        {
            Time.timeScale = 1;
            SampleGame.GameManager.Instance.ReloadLevel();
            if(MenuManager.Instance!=null && MenuMain.Instance!=null)
            {
                MenuManager.Instance.OpenMenu(MenuMain.Instance);
            }
        }
        public override void OnBackPressed()
        {
            Application.Quit();
        }
        public void OnQuitPressed()
        {
            Application.Quit();
        }

    }
}
