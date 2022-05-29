using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject lazer;
    public float spawnDistance = 2;
    public float shotCooldown = 1;

    [SerializeField] AudioClip laserSound;

    float nextFireTime;
    private AudioSource myAudio;
    void Shoot()
    {
        Vector3 playerPos = transform.position;
        Vector3 playerDirection = transform.forward;
        Quaternion playerRotation = transform.rotation;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        Instantiate(lazer, spawnPos, playerRotation);
        ShootSound();
    }

    void ShootSound()
    {
        if (!myAudio.isPlaying)
        {
            myAudio.PlayOneShot(laserSound);
        }
    }

    private void Start()
    {
        myAudio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                nextFireTime = Time.time + shotCooldown;
            }
        }
    }
}
