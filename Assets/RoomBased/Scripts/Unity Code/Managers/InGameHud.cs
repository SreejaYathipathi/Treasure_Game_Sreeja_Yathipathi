using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class InGameHUD : MonoBehaviour
{
    [SerializeField] private Text Timer;
    public TextMeshProUGUI HealthPoints;
    public TextMeshProUGUI ScorePoints;
    public static InGameHUD Instance;

    public int Health;
    public int Score;
    

    private bool _gamePaused = true;
    private float _timer = 0.0f;

    private void Start()
    {
        Timer.text = "Timer Paused";
        Timer.color = Color.yellow;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Prevent duplicate instances
            return;
        }

        Instance = this;
    }

    public void OnStartGame()
    {
        _gamePaused = false;
    }

    private void Update()
    {
        if(_gamePaused)
        {
            return;
        }

        _timer += Time.deltaTime;
        Timer.text = $"{_timer,0:0.000}";
    }

    public void OnPauseGame()
    {
        _gamePaused = true;
    }

    public void IncreaseHealth(int value)
    {
        Health += value;
        HealthPoints.text = $"{Health}";
    }

    public void IncreaseScore(int value)
    {
        Score += value;
        ScorePoints.text = $"{Score}";
    }
}
