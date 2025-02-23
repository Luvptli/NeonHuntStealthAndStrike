using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public int score = 0;                // Puntuación del jugador
    public TextMeshProUGUI scoreText;               // Texto UI para mostrar la puntuación
    private void Start()
    {
        UpdateScoreUI();
    }

    // Método que se llama cuando el jugador mata a un enemigo
    public void AddPointsForKill()
    {
        score += 4;  // Sumar 4 puntos por cada enemigo eliminado
        UpdateScoreUI();
    }

    // Método que se llama cuando el jugador dispara una bala
    public void SubtractPointsForShot()
    {
        score -= 1;  // Restar 2 puntos por cada bala disparada
        UpdateScoreUI();
    }

    // Actualiza el texto de la UI para mostrar la puntuación
    private void UpdateScoreUI()
    {
        scoreText.text = score.ToString();  // Asigna la puntuación al texto UI
    }
}
