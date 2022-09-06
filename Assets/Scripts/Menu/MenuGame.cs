using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LevelManagement
{
    public class MenuGame : Menu<MenuGame>
    {
        public void OnPausePressed()
        {
            Time.timeScale = 0;
            if (MenuManager.Instance != null && MenuPause.Instance != null)
            {
                MenuManager.Instance.OpenMenu(MenuPause.Instance);
            }
        }
    }
}
