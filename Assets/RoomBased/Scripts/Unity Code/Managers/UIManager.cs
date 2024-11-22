using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private LayoutTag[] Layouts;
    [SerializeField] private InGameHUD GameHud;

    private static MenuLayouts _currentLayout = MenuLayouts.Main;
    public enum MenuLayouts
    {
        Main,
        InGame,
        Pause,
        Instructions,
        ScrollView
    }
    private void Start()
    {
        //OpenMainMenu();
        //SetLayout(_currentLayout);
        if (_currentLayout == MenuLayouts.Main)
        {
            //GameHud.OnStartGame();
        }

        Layouts = GetComponentsInChildren<LayoutTag>();

        OpenMainMenu();
    }

    private void SetLayout(MenuLayouts Layout)
    {
        _currentLayout = Layout;

        Debug.Log($"Setting layout to {_currentLayout}");

        for(int i = 0; i < Layouts.Length; i++)
        {
            if (Layouts[i].myLayout == _currentLayout)
            {
                Layouts[i].EnableLayout();
            }
            else
            {
                Layouts[i].DisableLayout();
            }
        }
    }
    public void OpenMainMenu()
    {
        SetLayout(MenuLayouts.Main);
    }

    public void ActivateInGameHud()
    {
        SetLayout(MenuLayouts.InGame);
    }

    public void ShowPauseGameMenu()
    {
        SetLayout(MenuLayouts.Pause);
    }

    public void ShowInstructionsMenu()
    {
        SetLayout(MenuLayouts.Instructions);
    }

    public void ShowBagMenu()
    {
        SetLayout(MenuLayouts.ScrollView);
    }
}
