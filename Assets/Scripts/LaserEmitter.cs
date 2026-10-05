using System.Collections;
using UnityEngine;

public class LaserEmitter : MonoBehaviour
{
    [SerializeField] GameSettings settings;
    [SerializeField] GameManager manager;
    [SerializeField] Transform target;
    [SerializeField] Laser laser;

    private Coroutine coroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager.Active += OnActive;
    }

    void OnDestroy()
    {
        manager.Active -= OnActive;
    }

    private void OnActive(bool active)
    {
        if (active) coroutine = StartCoroutine(Activate());
        else StopCoroutine(coroutine);

    }

    private IEnumerator Activate()
    {
        WaitForSeconds waitForSeconds = new(settings.laserPeriod);

        while (true)
        {
            var laserObj = Instantiate(laser);

            laserObj.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)));
            laserObj.Target = target;

            yield return waitForSeconds;
        }
    }
}
