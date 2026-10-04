using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Buff")]
    [Min(0)] public float buffHeal = 10;

    [Header("Laser")]
    [Min(0)] public float laserDamage = 20;

    [Min(0)] public float laserPeriod = 1;
    [Min(0)] public float laserSpeed = 10;

    [Header("Audio")]
    public AudioClip winSound;
    public AudioClip loseSound;
}
