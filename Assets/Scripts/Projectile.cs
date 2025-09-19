using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f; // Time before projectile is destroyed

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Apply initial velocity in the forward direction of the projectile
        rb.linearVelocity = transform.forward * speed;

        // Destroy the projectile after 'lifetime' seconds
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Projectile hit: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject); // Destroy projectile on impact
    }
}