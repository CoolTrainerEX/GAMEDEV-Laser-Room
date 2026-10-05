using UnityEngine;

public class Buff : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.GetComponent<PlayerStats>().Buff();
        Destroy(gameObject);
    }
}
