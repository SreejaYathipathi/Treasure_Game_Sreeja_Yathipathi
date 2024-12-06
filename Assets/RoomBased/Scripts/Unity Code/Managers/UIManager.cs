using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    private LayoutTag[] Layouts;
    [SerializeField] private InGameHUD GameHud;
    [SerializeField] private GameObject _messagePanel; // Assign in Inspector
    [SerializeField] private TextMeshProUGUI _messageText; // Assign in Inspector
    [SerializeField] public GameObject EnemyHealthPanel;
    [SerializeField] public TextMeshProUGUI EnemyHealthPoints;

    public int _enemyHealth;

    private static MenuLayouts _currentLayout = MenuLayouts.Main;
    public enum MenuLayouts
    {
        Main,
        InGame,
        Pause,
        Instructions,
        TSearchPanel,
        NoSPanel,
        CIPanel,
        FCPanel,
        WCPanel,
        ECPanel,
        ACPanel,
        Inventory,
        LosePanel,
        WinPanel

    }
    private void Start()
    {
        if (_currentLayout == MenuLayouts.Main)
        {
            GameHud.OnStartGame();
        }

        Layouts = GetComponentsInChildren<LayoutTag>();

        OpenMainMenu();
    }

    public void SetLayout(MenuLayouts Layout)
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

    public void TreasureSearchPanel()
    {
        SetLayout(MenuLayouts.TSearchPanel);
    }
    
    public void NoSearchPanel()
    {
        SetLayout(MenuLayouts.NoSPanel);
    }
    
    public void CombatInstructionPanel()
    {
        SetLayout(MenuLayouts.CIPanel);
    }
    
    public void FireCombatPanel()
    {
        SetLayout(MenuLayouts.FCPanel);
    }
    
    public void WaterCombatPanel()
    {
        SetLayout(MenuLayouts.WCPanel);
    }
    
    public void EarthCombatPanel()
    {
        SetLayout(MenuLayouts.ECPanel);
    }
    
    public void AirCombatPanel()
    {
        SetLayout(MenuLayouts.ACPanel);
    }

    public void ShowMessagePanel(string message)
    {
        _messageText.text = message;
        _messagePanel.SetActive(true);
    }

    public void HideMessagePanel()
    {
        _messagePanel.SetActive(false);
    }

    public void ShowInventoryPanel()
    {
        SetLayout(MenuLayouts.Inventory); // Switch layout to inventory
    }

    public void PlayerLostPanel()
    {
        SetLayout(MenuLayouts.LosePanel);
    }
    
    public void PlayerWonPanel()
    {
        SetLayout(MenuLayouts.WinPanel);
    }
}
