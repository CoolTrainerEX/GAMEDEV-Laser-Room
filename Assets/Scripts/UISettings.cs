using UnityEngine;

[CreateAssetMenu(fileName = "UISettings", menuName = "Scriptable Objects/UISettings")]
public class UISettings : ScriptableObject
{
    [Min(0)] public float transitionSpeed = 50;
}
