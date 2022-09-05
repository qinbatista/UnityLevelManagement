using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    [RequireComponent(typeof(Canvas))]
    public class Menu : MonoBehaviour
    {
        public void OnPlayPressed()
        {
            // GameManager.Instance.ReloadLevel();
            SampleGame.GameManager.Instance.ReloadLevel();
        }
        public void OnSettingsPressed()
        {
            Menu menu = transform.parent.Find("UISetting(Clone)").GetComponent<Menu>();
            if (MenuManager.Instance != null && menu != null)
            {
                MenuManager.Instance.OpenMenu(menu);
            }
        }
        public void OnCreditsPressed()
        {
            Menu menu = transform.parent.Find("UICredits(Clone)").GetComponent<Menu>();
            if (MenuManager.Instance != null && menu != null)
            {
                MenuManager.Instance.OpenMenu(menu);
            }
        }
        public void OnBackPress()
        {
            MenuManager menuManager = Object.FindObjectOfType<MenuManager>();
            if (menuManager != null)
            {
                menuManager.CloseMenu();
            }
        }
    }
}

