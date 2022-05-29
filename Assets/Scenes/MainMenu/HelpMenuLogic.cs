using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenuLogic : MonoBehaviour
{
    [SerializeField] GameObject helpMenu;
    [SerializeField] GameObject mainMenu;

    public void BackButton()
    {
        helpMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
