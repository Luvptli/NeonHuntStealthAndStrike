using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField]
    GenericPool genericPool;

    [SerializeField]
    float radioAlcance;
    [SerializeField]
    LayerMask layerEnemigos;

    //Para disparar
    [SerializeField]
    public bool canShoot;

    //Para que la bala persiga
    public GameObject robotADisparar;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;      
    }

    // Update is called once per frame
    void Update()
    {
        ExplosionDamage();
        canShoot = true;
    }
    void ExplosionDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radioAlcance, layerEnemigos);
        foreach (var hitCollider in hitColliders)
        {
            if (canShoot == true)
            {
                robotADisparar = hitCollider.gameObject;
                canShoot = false;
                Debug.Log(hitCollider.gameObject.name);
                /* if (hitCollider != robotADisparar && !canShoot)
                 {
                     robotADisparar = null;
                     canShoot = true;
                 }
                 Debug.Log(robotADisparar.name);*/
            }
        }
        canShoot = true;//Hacer que si se sale del area el canShoot vuelve a ser true <-Para que busque un nuevo objetivo // Poner en los enemigos un distintivo para que se sepa que es a ese al que se le va a apuntar //Agrandar el mapa y añadir más enemigos //sonidos "efectos especiales" (disparos)
    }

}
