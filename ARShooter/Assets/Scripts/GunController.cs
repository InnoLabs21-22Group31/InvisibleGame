using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GunController : MonoBehaviour {
    public Camera playerCamera;
    public float range = 100f;
    public float rateOfFire = 1f;
    public int ammoCapacity = 7;
    public ParticleSystem muzzleFlash;
    public float reloadTime = 2f;
    public GameObject player;

    private PlayerController _playerController;
    private int _loadedAmmo;
    private bool _reloading = false;
    private float _gunReadyAt = 0f;


    private void Start() {
        _playerController = player.GetComponent<PlayerController>();
        _loadedAmmo = ammoCapacity;
        DisplayAmmo();
    }

    // Update is called once per frame
    void Update() {
        if (_reloading) return;

        if (!Debug.isDebugBuild) return;
        if (Input.GetButton("Fire1"))
            Fire();
        else if (Input.GetKeyDown("r")) {
            StartReloading();
        }
    }

    public void Fire() {
        if (!(Time.time >= _gunReadyAt && _loadedAmmo > 0))
            return;

        RaycastHit hit;
        muzzleFlash.Play();
        _gunReadyAt = Time.time + 1f / rateOfFire;
        RemoveAmmo();

        // Fire straight ahead
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range)) {
            var hitGO = hit.transform.gameObject;

            if (hitGO && hitGO.CompareTag("Enemy")) {
                var hitGOScript = hitGO.GetComponent<EnemyController>();
                if (hitGOScript) {
                    hitGOScript.Hit();
                }
            }
        }
    }

    private void RemoveAmmo() {
        _loadedAmmo--;
        DisplayAmmo();
    }

    private void DisplayAmmo() {
        _playerController.SetAmmoDisplay(_loadedAmmo, ammoCapacity);
    }

    public void StartReloading() {
        _reloading = true;
        StartCoroutine(Reload());
    }

    private IEnumerator Reload() {
        Debug.Log("reloading");
        yield return new WaitForSeconds(reloadTime);
        _loadedAmmo = ammoCapacity;
        DisplayAmmo();
        _reloading = false;
    }
}