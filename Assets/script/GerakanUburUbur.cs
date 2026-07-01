using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakanUburUbur : MonoBehaviour
{
    [Header("Pengaturan Gerakan")]
    [SerializeField] private float jarakGerak = 2f;    // Seberapa jauh ubur-ubur bergeser
    [SerializeField] private float kecepatanGerak = 2f; // Seberapa cepat ubur-ubur berenang
    
    [Header("Arah Gerakan")]
    [SerializeField] private bool gerakKananKiri = true; // Jika dicentang akan gerak kanan-kiri, jika tidak akan atas-bawah

    private Vector3 posisiAwal;

    void Start()
    {
        // Menyimpan posisi awal ubur-ubur saat game pertama kali dimulai
        posisiAwal = transform.position;
    }

    void Update()
    {
        // Hanya bergerak jika game sedang dalam kondisi berjalan (Playing)
        if (GameManager.Instance != null && GameManager.Instance.GameState == GameState.Playing)
        {
            // Menghitung perpindahan posisi secara halus menggunakan fungsi Sinus
            float hitungGerak = Mathf.Sin(Time.time * kecepatanGerak) * jarakGerak;

            if (gerakKananKiri)
            {
                // Mengubah posisi koordinat X (Kanan - Kiri)
                transform.position = new Vector3(posisiAwal.x + hitungGerak, transform.position.y, transform.position.z);
            }
            else
            {
                // Mengubah posisi koordinat Y (Atas - Bawah)
                transform.position = new Vector3(transform.position.x, posisiAwal.y + hitungGerak, transform.position.z);
            }
        }
    }
}