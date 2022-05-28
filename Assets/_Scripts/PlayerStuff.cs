using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuff : MonoBehaviour
{
    public GameObject lazer,revivePS;
    Manager man;
    int lives = 3;
    public float spawnDistance = 2;//lazer spawn distance away from character
    void Shoot()
    {
        Vector3 playerPos = transform.position;
        Vector3 playerDirection = transform.forward;
        Quaternion playerRotation = transform.rotation;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        Instantiate(lazer, spawnPos, playerRotation);
        ShootSound();
    }
    private void Start()
    {
        man = GameObject.FindGameObjectWithTag("manager").GetComponent<Manager>();
        myAudio = gameObject.GetComponent<AudioSource>();

    }
    public int getLives() { return lives; }
    public void setMaxLives() { lives = 3; }
    void death() {
        lives--;

        //update UI hearts
        man.updateHealthUI();
        //death animation

        if (lives <= 0) {
            man.GameOver();
            return;
        }
        //relocate the player
        man.respawnPlayer();
        //revive particel system
        Instantiate(revivePS, gameObject.transform);
        
    }
    void ShootSound()
    {
        if (!myAudio.isPlaying)
        {
            myAudio.PlayOneShot(laserSound);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.LogWarning("TRIGGER");
        if (other.gameObject.tag == "monster") {
            death();
        }
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
