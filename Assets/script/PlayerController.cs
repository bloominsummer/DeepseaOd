using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Floating (Saat Diam)")]
    [SerializeField] private float floatAmplitude = 0.15f;
    [SerializeField] private float floatSpeed = 4f;

    [Header("Movement (Saat Jalan)")]
    [SerializeField] private float forwardSpeed = 3f; 
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float rotationSpeed = 20f;

    private Rigidbody2D rg;
    private Vector3 startPosition;
    
    // Variabel penanda apakah ikan sudah mulai jalan atau belum
    private bool sudahMulaiMaju = false; 

    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        startPosition = transform.position; 
        ResetPlayer();
    }

    void Update()
    {
        // Deteksi tap pertama kali atau lompatan berikutnya
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            // Jika ini adalah tap pertama kali, ubah status menjadi mulai maju
            if (!sudahMulaiMaju)
            {
                sudahMulaiMaju = true;
                rg.simulated = true; // Aktifkan fisika/gravitasi saat mulai
            }
            
            Lompat();
        }

        // Logika pergerakan berdasarkan status ikan
        if (!sudahMulaiMaju)
        {
            // Jika belum di-tap, ikan hanya mengambang naik-turun lucu di tempat
            FloatIdle();
        }
        else
        {
            // Jika sudah di-tap, ikan otomatis berenang maju ke kanan dan badannya berotasi
            if (GameManager.Instance.GameState == GameState.Playing) 
            {
                MajuOtomatis(); 
                RotateFish();
            }
        }
    }

    private void FloatIdle()
    {
        // Membuat efek mengambang tenang di posisi awal
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(startPosition.x, newY, transform.position.z);
        transform.rotation = Quaternion.identity; // Tetap tegak lurus saat diam
    }

    private void MajuOtomatis()
    {
        rg.velocity = new Vector2(forwardSpeed, rg.velocity.y);
    }

    private void RotateFish()
    {
        float angle = Mathf.Clamp(rg.velocity.y * 5f, -90f, 30f);
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(0, 0, angle),
            rotationSpeed * Time.deltaTime
        );        
    }

    private void Lompat()
    {
        rg.velocity = new Vector2(rg.velocity.x, 0f);
        rg.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            GameManager.Instance.LoseLife();
        }
    }

    public void ResetPlayer()
    {
        sudahMulaiMaju = false; // Kembalikan status ke belum mulai
        rg.simulated = false;   // Matikan dulu fisika agar tidak jatuh ke bawah saat diam
        rg.velocity = Vector2.zero;
        rg.angularVelocity = 0f;
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
    }
}