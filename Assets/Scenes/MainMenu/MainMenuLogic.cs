using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject helpMenu;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HowToPlay()
    {
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
