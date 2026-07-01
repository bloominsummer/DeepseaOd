using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraIkutIkan : MonoBehaviour
{
    [Header("Pengaturan Kamera")]
    public Transform targetIkan; // Tempat menaruh objek Player nanti
    public float jarakX = 2f;    // Jarak horizontal agar kamera agak di depan ikan

    private float posisiAwalY;

    void Start()
    {
        // Mencatat posisi awal Y kamera agar kamera tidak ikut naik-turun ekstrem saat ikan melompat
        posisiAwalY = transform.position.y;
    }

    void LateUpdate()
    {
        // Kamera hanya akan bergerak jika targetIkan sudah dihubungkan di Inspector
        if (targetIkan != null)
        {
            // Mengikuti posisi X si ikan secara real-time, sementara posisi Y dan Z-nya dikunci tetap
            transform.position = new Vector3(targetIkan.position.x + jarakX, posisiAwalY, transform.position.z);
        }
    }
}
