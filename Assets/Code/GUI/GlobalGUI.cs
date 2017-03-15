using UnityEngine;

namespace GameProgramming1.GUI
{




    public class GlobalGUI : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

       
    }
}