using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    
    public UIDocument UI;
    
    void Start()
    {

        var root = UI.rootVisualElement;

        var startBtn = root.Q<Button>("Start");
        startBtn.clicked += StartBtn_clicked;

        var exitBtn = root.Q<Button>("Exit");
        exitBtn.clicked += ExitBtn_clicked;

    }

    private void ExitBtn_clicked()
    {
        Application.Quit();
    }

    private void StartBtn_clicked()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
}
