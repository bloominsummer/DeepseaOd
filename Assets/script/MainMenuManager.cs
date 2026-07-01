using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Start Screen")]
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject playButton;

    [Header("Game Ready Section")]
    [SerializeField] private GameObject gameReadyPanel;
    [SerializeField] private GameObject player;

    private GameState gameState = GameState.Home;
    public GameState GameState => gameState;

    void Start()
    {
        gameState = GameState.Home;
        logo.SetActive(true);
        playButton.SetActive(true);

        gameReadyPanel.SetActive(false);
        player.SetActive(false);
    }

    // Fungsi ini akan dipanggil pas tombol Play diklik
    public void PlayButtonClick()
    {
        gameState = GameState.GetReady;
        logo.SetActive(false);
        playButton.SetActive(false);

        gameReadyPanel.SetActive(true);
        player.SetActive(true);
    }

    void Update()
    {
        // Kalau sudah di screen Get Ready, dan player nge-klik mouse kiri / tap layar
        if (gameState == GameState.GetReady && Input.GetMouseButtonDown(0))
        {
            // Pindah ke scene Level 1. Pastikan nama di dalam tanda kutip ini
            // SAMA PERSIS dengan nama file scene gameplay-mu nanti.
            SceneManager.LoadScene("S1"); 
        }
    }
}