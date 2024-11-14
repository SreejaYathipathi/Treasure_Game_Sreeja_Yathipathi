using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void ButtonStartGame()
    {
        gameObject.SetActive(false);
        //UISystem.ActivateInGameHud();
        //GameHud.OnStartGame();
    }
}
