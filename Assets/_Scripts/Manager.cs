using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Manager : MonoBehaviour
{
    public Transform Spawnpoints;
    public TextMeshProUGUI waveText;
    public GameObject lilMonsterPrefab, tallMonsterPrefab;
    public AudioClip[] Sounds;
    AudioSource speaker;
    int wave = 0,totalMonsterCounter=0;
    WaitForSeconds wait = new WaitForSeconds(3);
    bool waveDone = false;
    void spawnMonster()
    {//spawns monster at random location in Spawnpoints
        int rand = Random.Range(0, Spawnpoints.transform.childCount - 1);
        int bigOrSmall = Random.Range(0, 2);
        if (bigOrSmall == 0)
            Instantiate(lilMonsterPrefab, Spawnpoints.GetChild(rand).position, Quaternion.identity);
        else
            Instantiate(tallMonsterPrefab, Spawnpoints.GetChild(rand).position, Quaternion.identity);
    }
    void GameOver() {
        //play Sound effect "Gameover"
        speaker.PlayOneShot(Sounds[2]);
        //show score and wave #
        //return to main menu
    }
    #region Wave Controllers
    void startNextWave() {
        
        if (wave == 0)
            speaker.PlayOneShot(Sounds[0]);//play Sound effect "Game start"
        else
            speaker.PlayOneShot(Sounds[1]);//play Sound effect "next round"


        wave++;
        waveDone = false;
        //set UI wave Text
        waveText.text = "Wave " + wave;
        totalMonsterCounter = wave * 2;
        for (int i = 0; i < totalMonsterCounter; i++) {//spawn monsters
            spawnMonster();
        }

    }
    public void killedMonster() {
        totalMonsterCounter--;
        if (totalMonsterCounter <= 0)//if round is done, pause for a few seconds
        {
            waveDone = true;
            StartCoroutine("waveEnd");
        }
    }
    IEnumerator waveEnd() {
        yield return wait;
        //play Sound effect "scary sound effect
        speaker.PlayOneShot(Sounds[3]);
        startNextWave();
    }
    #endregion
    void Start()
    {
        speaker = GetComponent<AudioSource>();
        startNextWave();
    }

    void Update()
    {

    }
}
