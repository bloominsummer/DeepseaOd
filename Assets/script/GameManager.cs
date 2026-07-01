using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Score")]
    [SerializeField] private TMP_Text score;

    [Header("References")]
    [SerializeField] private PlayerController playerController;

    [Header("Life")]    
    [SerializeField] private GameObject[] hearts;

    private int life;

    private GameState gameState = GameState.Playing; 

    public GameState GameState => gameState;
    private int currentScore;
    
    public int CurrentScore
    {
        get => currentScore;
        set
        {
            currentScore = value;
            if (score != null) score.text = currentScore.ToString();
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        gameState = GameState.Playing;
        CurrentScore = 0;

        life = hearts.Length;

        foreach (GameObject heart in hearts)
        {
            heart.SetActive(true);
        }

        if (score != null) score.gameObject.SetActive(true);

        if (playerController != null)
        {
            playerController.ResetPlayer();
            
            Rigidbody2D playerRb = playerController.GetComponent<Rigidbody2D>();
            if (playerRb != null) playerRb.simulated = true;
        }
    }

    public void ResetGame()
    {
        if (playerController != null)
        {
            playerController.ResetPlayer();

            Rigidbody2D playerRb = playerController.GetComponent<Rigidbody2D>();
            if (playerRb != null)
                playerRb.simulated = true;
        }

        gameState = GameState.Playing;
    }

    public void AddScore()
    {
        if (gameState != GameState.Playing) return;
        CurrentScore++;
    }

    public void LoseLife()
    {
        life--;

        if (life >= 0 && life < hearts.Length)
        {
            hearts[life].SetActive(false);
        }

        if (life <= 0)
        {
            GameOver();
        }
        else
        {
            playerController.ResetPlayer();

            Rigidbody2D rb = playerController.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.simulated = true;
        }
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;

        Debug.Log("GAME OVER");

        // nanti bisa ditambahkan panel Game Over
    }
}