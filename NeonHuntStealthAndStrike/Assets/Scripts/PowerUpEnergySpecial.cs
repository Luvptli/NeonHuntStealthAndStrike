using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEnergySpecial : MonoBehaviour
{
    [SerializeField] EnergySystem energySystem;
    public float invencible = 5;
    public bool invencibleBool = false;
    void Start()
    {
        energySystem = FindObjectOfType<EnergySystem>();
        invencibleBool = false;
    }

    private void Update()
    {
        if (invencibleBool == true) 
        {
            invencible -= Time.deltaTime;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            energySystem.totalEnergy = 100;
            invencibleBool = true;
            
            InvincibleHability();
        }
    }
    private void InvincibleHability()
    {
        if (invencible <= 0)
            {
                invencibleBool = false;
                invencible = 5;
            }
    }
}
