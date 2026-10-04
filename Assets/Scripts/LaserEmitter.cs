using System.Collections;
using UnityEngine;

public class LaserEmitter : MonoBehaviour
{
    [SerializeField] GameSettings settings;
    [SerializeField] Transform target;
    [SerializeField] Laser laser;

    private Coroutine coroutine;

    public bool Active
    {
        set
        {
            if (value) coroutine = StartCoroutine(DelayedLoop());
            else StopCoroutine(coroutine);

        }
    }

    private IEnumerator DelayedLoop()
    {
        while (true)
        {
            var laserObj = Instantiate(laser);

            laserObj.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)));
            laserObj.Target = target;

            yield return new WaitForSeconds(settings.laserPeriod);
        }
    }
}
