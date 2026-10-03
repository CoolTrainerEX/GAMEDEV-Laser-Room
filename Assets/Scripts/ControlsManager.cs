using UnityEngine;

public class ControlsManager : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
