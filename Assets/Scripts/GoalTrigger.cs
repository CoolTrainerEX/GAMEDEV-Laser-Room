using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [SerializeField] private GameManager manager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) manager.Win();
    }
}
