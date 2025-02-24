using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GenericPool bulletPool;

    public float speed = 20f;
    public float lifetime = 10f;
    private Vector3 direction;
    private PointsManager pointsManager;
    float maxDistance;

    Rigidbody bulletRb;

    private void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        pointsManager = FindObjectOfType<PointsManager>();
        //FindTarget();
    }

    private void FixedUpdate()
    {
        bulletRb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos si la bala toca a un enemigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (pointsManager != null)
            {
                pointsManager.AddPointsForKill();
            }
            Destroy(collision.gameObject); // Destruye al enemigo
        }

        bulletPool.ReturnToPool(gameObject); // Destruye la bala
    }
}
