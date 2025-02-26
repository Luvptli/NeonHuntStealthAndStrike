using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private EnemyCounter enemyCounter;
    public AudioClip wheelSFX;
    public AudioSource audioSource;
    public UIBehaviour uIBehaviour;

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

    private void Update()
    {
        if (uIBehaviour.estaJugando == true)
        {
            audioSource.PlayOneShot(wheelSFX);
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

}

