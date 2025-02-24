using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    GenericPool bulletsPool;
    
    public int maxAmmo = 2; 
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
        _animIDShoot = Animator.StringToHash("Shoot");
        _animIDReload = Animator.StringToHash("Reload");
        input = player.GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (input.shoot /*|| Input.GetMouseButtonDown(0)*/)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (isReloading) return; // Evita disparar mientras recarga

        if (currentAmmo > 0)
        {
            GameObject bullet = bulletsPool.GetElementFromPool();
            bullet.transform.position = shootPoint.position;
            bullet.transform.rotation = shootPoint.rotation;
            bullet.SetActive(true);
            audioSource.PlayOneShot(shootSFX);
            currentAmmo--;
            pointsManager.SubtractPointsForShot();
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
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}

