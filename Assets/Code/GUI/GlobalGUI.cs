using UnityEngine;

namespace GameProgramming1.GUI
{
    public class GlobalGUI : MonoBehaviour
    {
        private LoadingIndicator _loader;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            _loader  = GetComponentInChildren<LoadingIndicator>(true);
            _loader.Init();
        }
    }
}