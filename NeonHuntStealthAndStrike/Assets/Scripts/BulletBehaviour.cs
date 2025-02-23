using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 10f;
    private Vector3 direction;
    private PointsManager pointsManager;

    private void Start()
    {
        pointsManager = FindObjectOfType<PointsManager>();
        FindTarget();
        if (pointsManager != null)
        {
            pointsManager.SubtractPointsForShot();
        }
        Destroy(gameObject, lifetime);
        // Restar puntos al disparar
        
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length >20)
        {
            float minDistance = Mathf.Infinity;
            GameObject closestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = enemy;
                }
            }

            if (closestEnemy != null)
            {
                float alturaExtra = 3f;
                Vector3 targetPosition = closestEnemy.transform.position + Vector3.up * alturaExtra;
                direction = (targetPosition - transform.position).normalized;
                transform.LookAt(targetPosition);
            }
            else
            {
                direction = transform.forward;
            }
        }
        else
        {
            direction = transform.forward;
        }
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

        Destroy(gameObject); // Destruye la bala
    }
}
