using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI timeLabel;
    [SerializeField]
    public float timer = 420;
    [SerializeField]
    UIBehaviour uiBehaviour;
    void Update()
    {
        float minutos = Mathf.FloorToInt(timer / 60F);
        float segundos = Mathf.FloorToInt(timer % 60F);

        if (uiBehaviour.estaJugando==true)
        {
            timer -= Time.deltaTime;
            timeLabel.text = timer.ToString();
            timeLabel.text = string.Format("{0:00}:{1:00}", minutos, segundos);
            if (timer <= 0)
            {
                uiBehaviour.EndGame();
            }
        }
    }
}

