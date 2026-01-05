using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 25f;
    public float lifeTime = 3f;
    public GameObject explosionPrefab;

    private void Start()
    {
        
        Collider missileCol = GetComponent<Collider>();
        Collider droneCol = GameObject.FindGameObjectWithTag("Player")
                                      .GetComponent<Collider>();

        Physics.IgnoreCollision(missileCol, droneCol);

        Destroy(gameObject, lifeTime);

    }

private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Spawn explosion
        if (explosionPrefab != null)
        {
            Instantiate(
                explosionPrefab,
                transform.position,
                Quaternion.identity
            );
        }

        // Destroy targets or enemies
        if (collision.gameObject.CompareTag("Target") ||
            collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Missile hit " + collision.gameObject.tag + "!");
        }

        Destroy(gameObject);
    }
}


