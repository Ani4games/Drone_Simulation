using UnityEngine;

public class DroneShooting : MonoBehaviour
{
    public GameObject missilePrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;

    private float nextFireTime;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Debug.Log("Spawning: " + missilePrefab.name);
        Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
    }
}

