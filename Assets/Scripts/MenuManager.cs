using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class MenuManager : MonoBehaviour
    {
        public Menu mainMenuPrefab;
        public Menu settingsMenuPrefab;
        public Menu creditsMenuPrefab;
        Stack<Menu> _menuStack = new Stack<Menu>();
        [SerializeField] Transform _menuParent;
        static MenuManager _instance;
        public static MenuManager Instance { get => _instance; }

        void Awake()
        {
            if (_instance != null) { Destroy(gameObject); } else { _instance = this; InitializeMenus(); }
        }
        void OnDestroy()
        {
            if (_instance == this) { _instance = null; }
        }
        void InitializeMenus()
        {
            if (_menuParent == null)
            {
                GameObject menuParentObject = new GameObject("Menus");
                _menuParent = menuParentObject.transform;
            }
            Menu[] menuPrefab = { mainMenuPrefab, settingsMenuPrefab, creditsMenuPrefab };
            foreach (Menu prefab in menuPrefab)
            {
                if (prefab != null)
                {
                    Menu menuInstance = Instantiate(prefab, _menuParent);
                    if (prefab != mainMenuPrefab)
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else
                    {
                        OpenMenu(menuInstance);
                    }
                }
            }
        }
        public void OpenMenu(Menu menuInstance)
        {
            if (menuInstance == null)
            {
                Debug.LogError("MenuManager.OpenMenu(): menu is null!");
                return;
            }
            if (_menuStack.Count > 0)
            {
                foreach (Menu menu in _menuStack)
                {
                    menu.gameObject.SetActive(false);
                }
            }
            menuInstance.gameObject.SetActive(true);
            _menuStack.Push(menuInstance);
        }
        public void CloseMenu()
        {
            if (_menuStack.Count == 0)
            {
                Debug.LogError("MenuManager.CloseMenu(): no menus in stack!");
                return;
            }
            Menu topMenu = _menuStack.Pop();
            topMenu.gameObject.SetActive(false);
            if (_menuStack.Count > 0)
            {
                Menu nextMenu = _menuStack.Peek();
                nextMenu.gameObject.SetActive(true);
            }
        }
    }

}
