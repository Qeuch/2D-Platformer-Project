using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject startMainMenu;
    public GameObject levelSelect;
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LevelSelect()
    {
        startMainMenu.SetActive(false);
        levelSelect.SetActive(true);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
