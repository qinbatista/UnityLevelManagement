using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    [RequireComponent(typeof(ScreenFader))]
    public class SplashScreen : MonoBehaviour
    {
        [SerializeField] ScreenFader _screenFader;
        [SerializeField] float delay = 1f;
        void Awake()
        {
            _screenFader = GetComponent<ScreenFader>();
        }
        void Start()
        {
            _screenFader.FadeOn();
        }
        public void FadeAndLoad()
        {
            StartCoroutine(FadeAndLoadRoutine());
        }
        IEnumerator FadeAndLoadRoutine()
        {
            yield return new WaitForSeconds(delay);
            _screenFader.FadeOff();
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            yield return new WaitForSeconds(_screenFader.FadeDuration);
            Destroy(gameObject);
        }
    }
}

