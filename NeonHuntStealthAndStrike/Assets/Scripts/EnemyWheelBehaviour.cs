using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWheelBehaviour : MonoBehaviour
{
    // Referencia al NavMeshAgent del enemigo
    public NavMeshAgent enemyAgent;
    // Radio de la rueda (en unidades)
    public float wheelRadius = 0.5f;

    public AudioSource audioSource;
    public AudioClip wheelSFX;

    private void Start()
    {
        audioSource.PlayOneShot(wheelSFX);
    }
    void Update()
    {
        // Obtiene la velocidad actual del agente (en unidades/segundo)
        float speed = enemyAgent.velocity.magnitude;
        // Calcula la distancia recorrida en este frame
        float distance = speed * Time.deltaTime;
        // Calcula la circunferencia de la rueda: 2 * PI * radio
        float circumference = 2 * Mathf.PI * wheelRadius;
        // Calcula el ángulo que corresponde a la distancia recorrida:
        // Si la rueda recorre una circunferencia completa, rota 360°
        float angle = (distance / circumference) * 360f;
        // Rota la rueda en su eje local X (ajusta el eje según la orientación de tu rueda)
        transform.Rotate(0, 0, -angle, Space.Self);
    }
}

