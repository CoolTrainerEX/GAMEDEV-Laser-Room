using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StartTrigger : MonoBehaviour
{
    [SerializeField] private GameManager manager;

    private AudioSource audio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && manager.Activate()) audio.Play();
    }
}
