using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerScene1 : MonoBehaviour
{
    public static GameManagerScene1 Instance {get; private set;}

    [Header("Start Screen")]
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject playButton;

    [Header("Score")]
    [SerializeField] private TMP_Text score;

    [Header("Game Ready Section")]
    [SerializeField] private GameObject gameReadyPanel;

    [Header("Game Over Panel")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverScore;
    [SerializeField] private TMP_Text gameOverBestScore;

    [Header("References")]
    [SerializeField] private S1PlayerController playerController;

    private const string BEST_SCORE_KEY = "BestScore";

    private GameState gameState = GameState.Home;

    public GameState GameState => gameState;
    private int currentScore;
    public int CurrentScore
    {
        get => currentScore;
        set
        {
            currentScore = value;
            score.text = currentScore.ToString();
        }
    }
    private int BestScore
    {
        get => PlayerPrefs.GetInt(BEST_SCORE_KEY, 0);
        set
        {
            PlayerPrefs.SetInt(BEST_SCORE_KEY, value);
        }
    }
    private void Awake()
    {
        if(Instance !=null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        gameState = GameState.Home;
        logo.SetActive(true);
        playButton.SetActive(true);

        gameOverPanel.SetActive(false);
        gameReadyPanel.SetActive(false);
        score.gameObject.SetActive(false);
    }
    public void PlayButtonClick()
    {
        gameState = GameState.GetReady;
        CurrentScore = 0;

        logo.SetActive(false);
        playButton.SetActive(false);

        gameOverPanel.SetActive(false);
        gameReadyPanel.SetActive(true);
        score.gameObject.SetActive(true);

        ResetGame();
    }
    private void ResetGame()
    {
        playerController.ResetPlayer();
    }
    public void GamePlay()
    {
        gameState = GameState.Playing;
        gameReadyPanel.SetActive(false);
    }
    public void GameOver()
    {
        gameState = GameState.GameOver;
        score.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        playButton.SetActive(true);

        gameOverScore.text = CurrentScore.ToString();
        if(CurrentScore > BestScore)
        {
            BestScore = CurrentScore;
        }
        gameOverBestScore.text = BestScore.ToString();
    }
    public void AddScore()
    {
        if(gameState != GameState.Playing) return;

        CurrentScore++;
    }
}