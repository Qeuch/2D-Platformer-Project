using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public GameObject startMainMenu;
    public GameObject levelSelect;
    public TMP_InputField cheatInput;
    public CheatCodeManager cheatCodeManager;
    public PlayerController player;
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
        if (cheatInput.gameObject.activeSelf)
        {
            cheatInput.gameObject.SetActive(false);
        } else
        {
            cheatInput.gameObject.SetActive(true);
        }
     
    }

    public void SubmitCheat()
    {
        if (cheatInput != null)
        {
            CheatCodeManager cheatManager = FindFirstObjectByType<CheatCodeManager>();
            if (cheatManager != null)
            {
            cheatManager.checkCheats(cheatInput.text);
            cheatInput.text = "";
                
            } else
            {
                Debug.LogWarning("No cheat manager found");
            }
        }
    }

    public void DisableCheat()
    {
        CheatCodeManager cheatManager = FindFirstObjectByType<CheatCodeManager>();
        
        if ( cheatManager != null)
        {
            cheatManager.godModeActive = false;
            cheatManager.bunnyHopActive = false;
            
        }

        if (cheatInput != null)
        {
            cheatInput.text = "";
        }

    }
}
