using System;
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

    public static GameUIBehaviour instance;

    int enemysFixed;
    int enemys;
    int enemyConfined;

    AudioSource audioSource;
    public AudioClip questCompleted;

    [SerializeField]
    TextMeshProUGUI textEnemysLeft;

    [SerializeField]
    GameObject enemyParent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        //AddEnemie();
        audioSource = GetComponent<AudioSource>();
    }
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
    public void RemoveEnemie()
    {
        enemysFixed += 1;
        ActualizarEtiqueta();
        if (enemysFixed == enemys)
        {
            
            Debug.Log("Ha sonado la musica");
        }
    }
    public void AddEnemie()
    {
        //enemys = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemys += 1;
        ActualizarEtiqueta();
    }
    public void ActualizarEtiqueta()
    {
        textEnemysLeft.text = enemysFixed.ToString() + "/" + enemys.ToString();
    }
    public void SumaConfined()
    {
        enemyConfined = enemyParent.transform.childCount;
        enemys += enemyConfined;
        ActualizarEtiqueta();
    }
}

