using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    string sceneMenu = "Menu";
    string sceneGame = "Game";
    string sceneCharacterSelected = "SelectedCharacter";
    string sceneCredits = "Credits";
    string sceneTransition = "Transition";
    string sceneEndScreen = "EndScreen";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void goToSelectedCharacter()
    {
        StartCoroutine(sceneLoader(sceneCharacterSelected, 1.5f));
    }

    public void goToGameplay()
    {
        StartCoroutine(sceneLoader(sceneGame, 1.5f));
    }

    public void goToCredis()
    {
        StartCoroutine(sceneLoader(sceneCredits, 0.25f));
    }

    public void goToMenu()
    {
        StartCoroutine(sceneLoader(sceneMenu, 0.5f));
    }
    
    public void goToEndScreen()
    {
        StartCoroutine(sceneLoader(sceneEndScreen, 0.2f));
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator sceneLoader(string sceneName, float seconsWait)
    {
        SceneManager.LoadScene(sceneTransition); //Escena de transicion

        yield return null;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;


        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }

        yield return new WaitForSeconds(seconsWait);

        asyncLoad.allowSceneActivation = true;

        // Destroy(gameObject);
    }

}
