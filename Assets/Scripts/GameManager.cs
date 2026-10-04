using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private AudioSource audio;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private LaserEmitter laserEmitter;
    [SerializeField] private Buff buff;
    [SerializeField] private List<Transform> buffPositions;

    private bool _active = false;

    public bool Active
    {
        get => _active;
        private set
        {
            _active = value;
            laserEmitter.Active = value;

            if (value) foreach (var transform in buffPositions) Instantiate(buff).transform.SetPositionAndRotation(transform.position, transform.rotation);
            else
            {
                playerStats.Respawn();

                foreach (var gameObject in GameObject.FindGameObjectsWithTag("Game"))
                    Destroy(gameObject);
            }
        }
    }

    public void Activate()
    {
        Active = true;
    }

    public void Win()
    {
        Active = false;

        audio.PlayOneShot(settings.winSound);
    }

    public void Lose()
    {
        Active = false;

        audio.PlayOneShot(settings.loseSound);
    }
}
