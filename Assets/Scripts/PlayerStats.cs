using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerAudio))]
public class PlayerStats : MonoBehaviour
{
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private GameManager manager;
    [SerializeField] private Transform spawn;

    private PlayerAudio audio;
    public float Health { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<PlayerAudio>();

        manager.Active += OnActive;

        Respawn();
    }

    void OnDestroy()
    {
        manager.Active -= OnActive;
    }

    private void OnActive(bool active)
    {
        if (!active) Respawn();
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

    public void Buff()
    {
        StartCoroutine(BuffLoop());
    }

    private IEnumerator BuffLoop()
    {
        WaitForSeconds waitForSeconds = new(gameSettings.buffPeriod);

        for (int i = 0; i < gameSettings.buffTimes; i++)
        {
            AddHealth(gameSettings.buffHeal);

            yield return waitForSeconds;
        }
    }
}
