using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameHUD : MonoBehaviour
{
    [SerializeField] private Image HealthBar;
    [SerializeField] private Text Timer;

    private bool _gamePaused = true;
    private float _timer = 0.0f;

    private void Start()
    {
        Timer.text = "Timer Paused";
        Timer.color = Color.yellow;
    }

    public void OnStartGame()
    {
        _gamePaused = false;
        HealthBar.fillAmount = 1;
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

    public void OnHealthChange(float currentHealth, float maxHealth)
    {
        HealthBar.fillAmount = currentHealth / maxHealth;
    }
}
