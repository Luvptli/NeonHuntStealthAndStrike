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

    private float elapsedTime = 0f;
    void Update()
    {
        float minutos = Mathf.FloorToInt(timer / 60F);
        float segundos = Mathf.FloorToInt(timer % 60F);

        if (uiBehaviour.estaJugando==true)
        {
            elapsedTime += Time.deltaTime; // Accumulate elapsed time
            timer -= Time.deltaTime;
            timeLabel.text = timer.ToString();
            timeLabel.text = string.Format("{0:00}:{1:00}", minutos, segundos);
            if (timer <= 0)
            {
                int totalSeconds = Mathf.FloorToInt(elapsedTime);
                FindObjectOfType<PointsManager>().AddBonusPoints(totalSeconds * 10);
                uiBehaviour.EndGame();
            }
        }
    }
}

