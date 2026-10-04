using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameSettings settings;

    public Transform Target { private get; set; }

    // Update is called once per frame
    private void Update()
    {
        if (Target == null) return;

        if (transform.position == Target.position)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, Target.position, settings.laserSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.GetComponent<PlayerStats>().AddHealth(-settings.laserDamage);
        Destroy(gameObject);
    }
}
