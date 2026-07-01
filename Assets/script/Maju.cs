using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakMajuMusuh : MonoBehaviour
{
    [Header("Pengaturan Kecepatan")]
    [SerializeField] private float kecepatanMaju = 2f;
    
    [Header("Arah Maju")]
    [SerializeField] private bool majuKeKiri = true; // Centang = Maju ke kiri, Kosongkan = Maju ke kanan

    void Update()
    {
        // Cumi-cumi hanya akan bergerak maju jika game sedang berjalan (Playing)
        if (GameManager.Instance != null && GameManager.Instance.GameState == GameState.Playing)
        {
            // Tentukan arah berdasarkan pilihan di Inspector
            float arah = majuKeKiri ? -1f : 1f;

            // Menggeser posisi objek secara konstan ke arah X
            transform.Translate(Vector3.right * arah * kecepatanMaju * Time.deltaTime);
        }
    }
}