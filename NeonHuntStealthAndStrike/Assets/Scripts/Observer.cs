using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public UIBehaviour uIBehaviour;

    bool m_IsPlayerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }
    void Update()
    { 
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position;

            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {       
                    uIBehaviour.EndGame();
            }
        }
    }
}
