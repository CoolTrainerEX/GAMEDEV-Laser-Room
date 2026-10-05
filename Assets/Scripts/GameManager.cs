using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private AudioSource audio;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Buff buff;
    [SerializeField] private List<Transform> buffPositions;

    public bool IsActive { get; private set; } = false;
    public event Action<bool> Active;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Active += OnActive;
    }

    void OnDestroy()
    {
        Active -= OnActive;
    }

    private void OnActive(bool active)
    {
        IsActive = active;

        if (active)
            foreach (var transform in buffPositions) Instantiate(buff).transform.SetPositionAndRotation(transform.position, transform.rotation);
        else
            foreach (var gameObject in GameObject.FindGameObjectsWithTag("Game")) Destroy(gameObject);
    }

    private bool Deactivate()
    {
        if (!IsActive) return false;

        Active?.Invoke(false);

        return true;
    }

    public bool Activate()
    {
        if (IsActive) return false;

        Active?.Invoke(true);

        return true;
    }


    public bool Win()
    {
        var success = Deactivate();

        if (success) audio.PlayOneShot(settings.winSound);

        return success;
    }

    public bool Lose()
    {
        var success = Deactivate();

        if (success) audio.PlayOneShot(settings.loseSound);

        return success;
    }
}
