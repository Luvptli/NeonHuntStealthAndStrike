using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    GenericPool bulletsPool;
    
    //public int maxEnergy = 100; 
    //private int currentAmmo;
    private bool isReloading = false;
    public float reloadSpeed = 0.5f;

    public Animator _animator;
    private Animator _animator2;
    private int _animIDShoot;
    private int _animIDReload;

    [SerializeField] Transform shootPoint;
    public GameObject bulletPrefab;
    UIBehaviour uIBehaviour;
    [SerializeField] GameObject player;
    private PointsManager pointsManager;
    StarterAssetsInputs input;

    public AudioClip shootSFX;
    public AudioClip recharge;
    public AudioSource audioSource;

    bool canShoot = true;
    float coolDown = 2f;

    [SerializeField] ParticleSystem smokeEffectLeft; 
    [SerializeField] ParticleSystem smokeEffectRight;

    [SerializeField] EnergySystem energySystem;
    [SerializeField] PowerUpEnergySpecial powerUpSpecial;

    private void Start()
    {
        pointsManager = FindObjectOfType<PointsManager>();
        bulletsPool = player.GetComponent<GenericPool>();
        //currentAmmo = maxEnergy; 
        _animator = GetComponent<Animator>();
        input = player.GetComponent<StarterAssetsInputs>();
        _animIDShoot = Animator.StringToHash("Shoot");
        _animIDReload = Animator.StringToHash("Reload");
        input = player.GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (energySystem.totalEnergy <= 100)
        {
            energySystem.EnergyCount();
        }
        
        if (input.shoot && canShoot/*|| Input.GetMouseButtonDown(0)*/)
        {
            Shoot(); 
            input.shoot = false;
            audioSource.PlayOneShot(shootSFX);
            _animator.SetTrigger("Shoot");
        }
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDown);
        canShoot=true;
        yield return null;
    }

    public void Shoot()
    {
        if (isReloading) return; // Evita disparar mientras recarga

        if (energySystem.totalEnergy>33)
        {
            GameObject bullet = bulletsPool.GetElementFromPool();
            bullet.transform.position = shootPoint.position;
            bullet.transform.rotation = shootPoint.rotation;
            bullet.SetActive(true);
            
            pointsManager.SubtractPointsForShoot();
            canShoot = false;
            StartCoroutine(CoolDown());
            if (smokeEffectLeft != null) smokeEffectLeft.Play();
            if (smokeEffectRight != null) smokeEffectRight.Play();
            if (powerUpSpecial.invencibleBool == false)
            {
                energySystem.LoseEnergy();
                energySystem.timeToRegenerate = 10;
            }
            //_animator.SetTrigger(_animIDShoot); // Activar animación de disparo
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        //_animator.SetTrigger(_animIDReload); 
        yield return new WaitForSeconds(reloadSpeed);
        audioSource.PlayOneShot(recharge);
        //currentAmmo +=3;
        isReloading = false;
    }
}

