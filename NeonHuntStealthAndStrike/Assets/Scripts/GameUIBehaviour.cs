using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIBehaviour : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI timeLabel;
    [SerializeField]
    public float timer = 420;
    [SerializeField]
    public TextMeshProUGUI pointsLabel;
    [SerializeField]
    public float pointer = 0;
    [SerializeField]
    UIBehaviour uiBehaviour;

    bool m_IsPlayerCaught;

    void Update()
    {
        float minutos = Mathf.FloorToInt(timer / 60F);
        float segundos = Mathf.FloorToInt(timer % 60F);

        if (uiBehaviour.estaJugando==true)
        {
            timer -= Time.deltaTime;
            timeLabel.text = timer.ToString();
            timeLabel.text = string.Format("{0:00}:{1:00}", minutos, segundos);
            if (timer <= 0 || m_IsPlayerCaught)
            {
                uiBehaviour.EndGame();
            }
        }        
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }
}
