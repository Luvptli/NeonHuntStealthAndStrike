using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergySystem : MonoBehaviour
{
    public static EnergySystem instance;
    
    public int totalEnergy=100;
    public int energyToShoot = 33;
    public TextMeshProUGUI energyBar;
    public float timeToRegenerate = 10;
    int recuperation = 3;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        totalEnergy = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnergyCount()
    {
       timeToRegenerate-=Time.deltaTime;
       if (timeToRegenerate <= 0)
       {
           totalEnergy += recuperation;
           timeToRegenerate = 1;
       }
        
        else if (totalEnergy >= 100)
        {
            timeToRegenerate=10;
        }
        UpdateTotalEnergy();
    }

    public void LoseEnergy()
    {
        totalEnergy -= energyToShoot;
        UpdateTotalEnergy();
    }

    public void UpdateTotalEnergy()
    {
        energyBar.text = totalEnergy.ToString();
    }
}
