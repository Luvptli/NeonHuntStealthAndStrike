using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    GenericPool bulletsPool;
    
    public int maxAmmo = 4; 
    private int currentAmmo;
    private bool isReloading = false;
    public float reloadSpeed = 0.5f;

    private Animator _animator;
    private int _animIDShoot;
    private int _animIDReload;

    [SerializeField] Transform shootPoint;
    public GameObject bulletPrefab;
    public AudioClip[] shootAudioClips;
    public float shootAudioVolume = 0.5f;
    UIBehaviour uIBehaviour;
    [SerializeField] GameObject player;
    private PointsManager pointsManager;
    StarterAssetsInputs input;

    public AudioClip shootSFX;
    public AudioClip recharge;
    public AudioSource audioSource;

    private void Start()
    {
        pointsManager = FindObjectOfType<PointsManager>();
        bulletsPool = player.GetComponent<GenericPool>();
        currentAmmo = maxAmmo; 
        _animator = GetComponent<Animator>();
        input = player.GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        //Poner cooldown entre disparos
        if (input.shoot /*|| Input.GetMouseButtonDown(0)*/)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (!isReloading)
        {
            if (currentAmmo > 0)
            {
                GameObject bullet = bulletsPool.GetElementFromPool();
                bullet.transform.position = shootPoint.position;
                bullet.transform.rotation = shootPoint.rotation;
                bullet.SetActive(true);
                audioSource.PlayOneShot(shootSFX);
                currentAmmo--;
                pointsManager.SubtractPointsForShoot();
                _animator.SetTrigger("Shoot");
            }
            else
            {
                StartCoroutine(Reload());
            }
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadSpeed);
        audioSource.PlayOneShot(recharge);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}

