using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public int maxAmmo = 2; 
    private int currentAmmo;
    private bool isReloading = false;
    public float reloadSpeed = 0.5f;

    private Animator _animator;
    private int _animIDShoot;
    private int _animIDReload;

    public GameObject bulletPrefab;
    public Transform shootPoint;
    public AudioClip[] shootAudioClips;
    public float shootAudioVolume = 0.5f;
    UIBehaviour uIBehaviour;

    public AudioClip shootSFX;
    public AudioSource audioSource;

    private void Start()
    {
        currentAmmo = maxAmmo; 
        _animator = GetComponent<Animator>();
        _animIDShoot = Animator.StringToHash("Shoot");
        _animIDReload = Animator.StringToHash("Reload");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (isReloading) return; // Evita disparar mientras recarga

        if (currentAmmo > 0)
        {
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

            if (shootAudioClips.Length > 0)
            {
                var index = Random.Range(0, shootAudioClips.Length);
                audioSource.PlayOneShot(shootSFX);
            }

            currentAmmo--;
            //_animator.SetTrigger(_animIDShoot); // Activar animación de disparo
        }
        else
        {
            StartCoroutine(Reload()); // Si no hay balas, recargar
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        //_animator.SetTrigger(_animIDReload); // Activar animación de recarga
        yield return new WaitForSeconds(reloadSpeed); // Simula el tiempo de recarga

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}

