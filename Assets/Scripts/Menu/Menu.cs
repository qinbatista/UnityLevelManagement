using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public abstract class Menu<T>: Menu where T: Menu<T>
    {
        static T _instance;
        public static T Instance { get => _instance; set => _instance = value; }
        protected virtual void Awake()
        {
            if (_instance != null) { Destroy(gameObject); } else { _instance = (T)this; }
        }
        protected virtual void OnDestroy()
        {
            _instance = null;
        }
    }
    [RequireComponent(typeof(Canvas))]
    public abstract class Menu : MonoBehaviour
    {
        public virtual void OnBackPressed()
        {
            if (MenuManager.Instance != null)
            {
                MenuManager.Instance.CloseMenu();
            }
        }
    }
}

