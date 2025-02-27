using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEnergy : MonoBehaviour
{
    [SerializeField] EnergySystem energySystem;
    void Start()
    {
        energySystem = FindObjectOfType<EnergySystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (energySystem.totalEnergy< 100)
            {
                Destroy(gameObject);
                energySystem.totalEnergy = 100;
            }
        } 
    }
}

