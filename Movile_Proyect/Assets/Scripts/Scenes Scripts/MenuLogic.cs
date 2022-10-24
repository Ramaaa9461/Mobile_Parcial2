using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLogic : MonoBehaviour
{
    SceneController sceneController;

    void Awake()
    {
        sceneController = GameObject.Find("Scene_Controller").GetComponent<SceneController>();
    }

    public void goToSelectedCharacter()
    {
        sceneController.goToSelectedCharacter();
    }

    public void goToGameplay()
    {
        sceneController.goToGameplay();
    }

    public void goToCredis()
    {
        sceneController.goToCredis();
    }

    public void goToMenu()
    {
        sceneController.goToMenu();
    }
    public void goToEndScreen()
    {
        sceneController.goToEndScreen();
    }

    public void PauseGame()
    {
        sceneController.PauseGame();
    }

    public void ResumeGame()
    {
        sceneController.ResumeGame();
    }

    public void Exit()
    {
        sceneController.Exit();
    }

}
