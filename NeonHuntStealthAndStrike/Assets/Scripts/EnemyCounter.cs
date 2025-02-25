using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    // Variables para los contadores
    public int totalEnemies = 0;  // Total de enemigos en la escena
    public int eliminatedEnemies = 0;  // Enemigos eliminados

    public TextMeshProUGUI enemy;

    public UIBehaviour uIBehaviour;

    void Update()
    {
        enemy.text = eliminatedEnemies.ToString() + "  /  " + totalEnemies.ToString();
        if (totalEnemies == eliminatedEnemies)
        {
            uIBehaviour.WinGame();
        }
    }
    // Método para aumentar el total de enemigos
    public void AddEnemy()
    {
        totalEnemies++;
    }

    // Método para eliminar un enemigo y aumentar el contador de eliminados
    public void RemoveEnemy()
    {
        eliminatedEnemies++;
    }
}

