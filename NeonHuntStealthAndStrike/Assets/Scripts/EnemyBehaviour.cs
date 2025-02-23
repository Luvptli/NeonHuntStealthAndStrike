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

    // M�todo que se llama cuando el enemigo es destruido
    private void OnDestroy()
    {
        // Reducir el contador de enemigos cuando este enemigo es destruido
        if (enemyCounter != null)
        {
            enemyCounter.RemoveEnemy();
        }
    }

    // Aqu� puedes tener la l�gica de c�mo el enemigo es destruido (por ejemplo, por una bala)
    // Por ejemplo, el script de la bala llamar�a a Destroy(gameObject) cuando golpea al enemigo.
}

