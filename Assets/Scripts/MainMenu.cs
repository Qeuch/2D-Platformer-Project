using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public GameObject startMainMenu;
    public GameObject levelSelect;
    public TMP_InputField cheatInput;

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

    public void toggleCheat()
    {
        cheatInput.gameObject.SetActive(true);
    }

    public void SubmitCheat()
    {
        if (cheatInput != null)
        {
            cheatManager.checkCheat(cheatInput.text);
            cheatInput.text = "";
        }
    }
}
