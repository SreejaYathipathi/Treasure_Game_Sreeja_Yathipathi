using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIManager UISystem;
    [SerializeField] private InGameHUD GameHud;
    public void ButtonStartGame()
    {
        gameObject.SetActive(false);
        UISystem.ActivateInGameHud();
        GameHud.OnStartGame();
    }
}
