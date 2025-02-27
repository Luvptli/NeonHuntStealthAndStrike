using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEnergy : MonoBehaviour
{
    [SerializeField] EnergySystem energySystem;
    void Start()
    {
        energySystem =FindObjectOfType<EnergySystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            energySystem.totalEnergy = 100;
            Destroy(gameObject);
        }
    }
}
