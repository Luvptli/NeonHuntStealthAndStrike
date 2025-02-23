using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private EnemyCounter enemyCounter;

    private void Start()
    {
        // Buscar el GameManager o el objeto que tiene el script EnemyCounter
        enemyCounter = GameObject.Find("Enemies").GetComponent<EnemyCounter>();

        // Agregar este enemigo al contador de enemigos cuando el enemigo se crea
        if (enemyCounter != null)
        {
            enemyCounter.AddEnemy();
        }
    }

    // Método que se llama cuando el enemigo es destruido
    private void OnDestroy()
    {
        // Reducir el contador de enemigos cuando este enemigo es destruido
        if (enemyCounter != null)
        {
            enemyCounter.RemoveEnemy();
        }
    }

    // Aquí puedes tener la lógica de cómo el enemigo es destruido (por ejemplo, por una bala)
    // Por ejemplo, el script de la bala llamaría a Destroy(gameObject) cuando golpea al enemigo.
}

