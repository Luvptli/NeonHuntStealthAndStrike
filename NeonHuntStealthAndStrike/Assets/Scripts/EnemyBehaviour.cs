using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameUIBehaviour.instance.AddEnemie();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    public void EnemyLeft()
    {
            GameUIBehaviour.instance.RemoveEnemie();
    }
}
