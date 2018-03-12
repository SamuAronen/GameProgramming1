using System.Collections;
using System.Collections.Generic;
using GameProgramming1.Systems;
using UnityEngine;

namespace GameProgramming1.GUI
{

    public class LanguageButton : MonoBehaviour
    {
        [SerializeField] private LangCode _languge;


       public void OnClick()
        {
            Localization.LoadLanguage(_languge);
        }
    }
}