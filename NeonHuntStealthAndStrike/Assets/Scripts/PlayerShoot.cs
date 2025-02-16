using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public int maxAmmo = 2; 
    private int currentAmmo;
    private bool isReloading = false;

    private Animator _animator;
    private int _animIDShoot;
    private int _animIDReload;

    public GameObject bulletPrefab;
    public Transform shootPoint;
    public AudioClip[] shootAudioClips;
    public float shootAudioVolume = 0.5f;

    private void Start()
    {
        currentAmmo = maxAmmo; 
        _animator = GetComponent<Animator>();
        _animIDShoot = Animator.StringToHash("Shoot");
        _animIDReload = Animator.StringToHash("Reload");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (isReloading) return; // Evita disparar mientras recarga

        if (currentAmmo > 0)
        {
            // Instanciar la bala
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

            // Reproducir sonido de disparo si hay clips
            if (shootAudioClips.Length > 0)
            {
                var index = Random.Range(0, shootAudioClips.Length);
                AudioSource.PlayClipAtPoint(shootAudioClips[index], transform.position, shootAudioVolume);
            }

            currentAmmo--; // Disminuir la munición
            _animator.SetTrigger(_animIDShoot); // Activar animación de disparo
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
        yield return new WaitForSeconds(0.0002f); // Simula el tiempo de recarga

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}

