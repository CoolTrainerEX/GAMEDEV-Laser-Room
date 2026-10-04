using UnityEngine;

public class Buff : MonoBehaviour
{
    [SerializeField] private GameSettings settings;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.GetComponent<PlayerStats>().AddHealth(settings.buffHeal);
        Destroy(gameObject);
    }
}
