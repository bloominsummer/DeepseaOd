using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakMondarMandir : MonoBehaviour
{
    [Header("Pengaturan Rute")]
    [SerializeField] private float jarakGerak = 2f;    // Seberapa jauh dia pergi
    [SerializeField] private float kecepatanGerak = 2f; // Seberapa cepat dia berenang
    
    [Header("Arah Patroli")]
    [SerializeField] private bool gerakKananKiri = true; // Centang = Kanan-Kiri, Kosongkan = Atas-Bawah

    private Vector3 posisiAwal;

    void Start()
    {
        // Catat posisi berdirinya sekarang saat game mulai
        posisiAwal = transform.position;
    }

    void Update()
    {
        // Hanya bergerak kalau game lagi jalan
        if (GameManager.Instance != null && GameManager.Instance.GameState == GameState.Playing)
        {
            float hitungGerak = Mathf.Sin(Time.time * kecepatanGerak) * jarakGerak;

            if (gerakKananKiri)
            {
                // Rumus gerak Horizontal (Kanan - Kiri)
                transform.position = new Vector3(posisiAwal.x + hitungGerak, transform.position.y, transform.position.z);
            }
            else
            {
                // Rumus gerak Vertikal (Atas - Bawah)
                transform.position = new Vector3(transform.position.x, posisiAwal.y + hitungGerak, transform.position.z);
            }
        }
    }
}
