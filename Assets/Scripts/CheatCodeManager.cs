using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class CheatCodeManager : MonoBehaviour
{

    public void Awake()
    {
        CheatCodeManager[] others = FindObjectsByType<CheatCodeManager>(FindObjectsSortMode.None);
        if (others.Length > 1 )
        {
            Destroy(gameObject);
            return;
        }



        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        
    }

    public string godMode = "GODMODE";
    public string bunnyHop = "BUNNYHOP";

    public bool godModeActive = false;
    public bool bunnyHopActive = false;

    public PlayerController player;
    public PlayerHealth playerhealth;
    // Update is called once per frame
 
    public void checkCheats(string cheat)
    {
        if (cheat == godMode)
        {
            godModeActive = true;
        }

        if (cheat == bunnyHop)
        {
            bunnyHopActive = true;
        }
    }



    
}
