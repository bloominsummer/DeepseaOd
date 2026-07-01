using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S0Player : MonoBehaviour
{
    [Header("Floating Settings")]
    [SerializeField] private float floatAmplitude = 0.15f; // Jarak naik turunnya
    [SerializeField] private float floatSpeed = 3f;       // Kecepatan melayangnya

    private Vector3 startPosition;

    void Start()
    {
        // Menyimpan posisi awal karakter saat game pertama kali dijalankan di menu
        startPosition = transform.position;
    }

    void Update()
    {
        // Menjalankan gerakan melayang terus-menerus tanpa bergantung state game
        FloatIdle();
    }

    private void FloatIdle()
    {
        // Rumus Sinus untuk membuat gerakan naik turun yang halus (smooth)
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}