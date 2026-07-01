using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Dibutuhkan untuk pindah pindah level/scene

public class FinishLine : MonoBehaviour
{
    [Header("Pengaturan Level")]
    [SerializeField] private string namaSceneLevelTiga = "Level3"; // Tulis nama scene Level 3 kamu di sini

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Mengecek apakah objek yang masuk/menyentuh terumbu karang adalah Player
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hore! Ikan masuk finish. Pindah ke Level 3!");
            
            // Perintah untuk memuat dan membuka scene Level 3
            SceneManager.LoadScene(namaSceneLevelTiga);
        }
    }
}