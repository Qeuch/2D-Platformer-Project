using TMPro;
using UnityEngine;

public class CheatCodeManager : MonoBehaviour
{


    public string godMode = "GODMODE";
    public string bunnyHop = "BUNNYHOP";

    public PlayerHealth playerhealth;
    // Update is called once per frame



 
    public void checkCheats(string cheat)
    {
        if (cheat == godMode)
        {
            playerhealth.godMode = true;
        }

        if (cheat == bunnyHop)
        {

        }
    }

    public void activateCheats()
    {


    }

    
}
