using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private bool scored = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log($"Trigger: {gameObject.name} | ID: {GetInstanceID()}");

        if (scored) return;

        scored = true;

        Debug.Log("Tambah skor!");

        GameManager.Instance.AddScore(1);
    }
}