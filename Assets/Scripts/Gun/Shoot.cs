using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shoot : MonoBehaviour
{
    public int defaultAmmo = 120;
    public int magSize = 30;
    public int currentAmmo;
    public int currentMagAmmo;
    public Camera camera;
    public int range;
    [Header("Gun Damage On Hit")]
    public int damage;
    public ParticleSystem muzzleParticle;
    private AudioSource mAudoSrc;

    public Text ammoDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = defaultAmmo - magSize;
        currentMagAmmo = magSize;

        mAudoSrc = GetComponent<AudioSource>();
        ammoDisplay.text = "Ammo: " + currentMagAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Reload();
        }

        if (Input.GetMouseButtonDown(0))
        {
            mAudoSrc.Play();

            if (CanFire())
            {
                Fire();
            }

        }

        if (currentMagAmmo == 0 && magSize > 0)
        {
            currentAmmo = defaultAmmo - magSize;
            currentMagAmmo = magSize;
        }


    }

    private void Reload()
    {
        if (currentAmmo == 0 && currentMagAmmo == magSize)
        {
            return;
        }
        if (currentAmmo < magSize)
        {
            currentMagAmmo = currentMagAmmo + currentAmmo;
            currentAmmo = 0;

        }
        else
        {
            currentAmmo -= magSize - currentMagAmmo;
            currentMagAmmo = magSize;
            ammoDisplay.text = "Ammo: " + currentMagAmmo.ToString();
        }


    }

    private bool CanFire()
    {
        if (currentMagAmmo > 0)
        {
            return true;
        }
        return false;

    }

    private void Fire()
    {
        muzzleParticle.Play(true);
        currentMagAmmo -= 1;
        Debug.Log("Kalan Mermim " + currentMagAmmo);
        ammoDisplay.text = "Ammo: " + currentMagAmmo.ToString();
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 10)) ;
        {
            if (hit.transform.tag == "Zombie")
            {
                hit.transform.GetComponent<ZombieHealth>().Hit(damage);
            }

            else
            {

            }
        }


    }

}
