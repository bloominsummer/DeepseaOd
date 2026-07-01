using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Koin"))
        {
            Destroy(collision.gameObject);

            GameManager.Instance.AddScore(2);
        }
    }
}
