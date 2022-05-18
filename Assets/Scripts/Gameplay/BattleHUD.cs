using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    // [SerializeField] private Text heroHP;
    [SerializeField] private Image healthBar;
    [SerializeField] private Text score;
    [SerializeField] private Text arrowCount;
    
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject pauseMenu;
    
    [SerializeField] private GameObject nicknamePanel;
    [SerializeField] private Button saveButton; 
    [SerializeField] private Button cancelButton;
    [SerializeField] private Text nicknameText;

    [SerializeField] private AudioSource music;
    [SerializeField] private HealthStats hero;

    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        nicknamePanel.SetActive(false);
        pauseButton.onClick.AddListener(OnPauseClicked);
        restartButton.onClick.AddListener(OnRestartPressed);
        exitButton.onClick.AddListener(OnExitPressed);
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = hero.GetHPPercent();
        arrowCount.text = hero.GetArrowCount().ToString();
        score.text = hero.GetFrags().ToString();
    }

    private void OnPauseClicked()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
            pauseMenu.SetActive(false);
        }
    }

    public void OnDeath()
    {
        pauseMenu.SetActive(true);
    }

    private void OnRestartPressed()
    {
        Exit(SceneManager.GetActiveScene().name);
    }
    
    private void OnExitPressed()
    {
        Exit("MainMenu");
    }

    private void FinishScene(string nextSceneName, bool saveResults)
    {
        if (saveResults)
        {
            DatabaseService.Instance().AddToLeaderboard(nicknameText.text,hero.GetFrags());
        }

        SceneManager.LoadScene(nextSceneName);
    }
    
    private void Exit(string nextSceneName)
    {
        nicknamePanel.SetActive(true);
        pauseMenu.SetActive(false);

        Debug.Log(nextSceneName);
        saveButton.onClick.AddListener(delegate { FinishScene(nextSceneName, true);});
        cancelButton.onClick.AddListener(delegate { FinishScene(nextSceneName, false);});
    }
}
