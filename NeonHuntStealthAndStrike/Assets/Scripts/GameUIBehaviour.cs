using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIBehaviour : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI timeLabel;
    [SerializeField]
    public float timer;
    [SerializeField]
    public TextMeshProUGUI pointsLabel;
    [SerializeField]
    public float pointer;
    [SerializeField]
    public UIBehaviour uiBehaviour;

    //añadir cuando en ui behaviour le des a start comienza a contar el tiempo

    void Start()
    {
        timer = 7;
        pointer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeLabel.text = timer.ToString();
        pointsLabel.text = pointsLabel.ToString();  
    }
}
