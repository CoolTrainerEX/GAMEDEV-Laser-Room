using UnityEngine;

[RequireComponent(typeof(PlayerAudio))]
public class PlayerStats : MonoBehaviour
{
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private GameManager manager;
    [SerializeField] private Transform spawn;

    private PlayerAudio audio;
    public float Health { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<PlayerAudio>();

        Respawn();
    }

    public void Respawn()
    {
        Health = settings.maxHealth;
        transform.SetPositionAndRotation(spawn.position, spawn.rotation);
    }

    public void AddHealth(float add)
    {
        Health = Mathf.Clamp(Health + add, 0, settings.maxHealth);

        if (add > 0) audio.Heal();
        else audio.Damage();

        if (Health <= 0) manager.Lose();
    }
}
