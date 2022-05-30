using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Manager : MonoBehaviour
{
    public Transform Spawnpoints;
    public TextMeshProUGUI waveText;
    public GameObject lilMonsterPrefab, tallMonsterPrefab,healthUI;
    public AudioClip[] Sounds;
    AudioSource speaker;
    int wave = 0, totalMonsterCounter = 0;
    int score = 0;
    WaitForSeconds wait = new WaitForSeconds(3);
    public PlayerStuff player;
    bool waveDone = true;

    [SerializeField] GameObject character;
    [SerializeField] GameObject characterModel;
    [SerializeField] TextMeshProUGUI scoreText;
    void spawnMonster()
    {//spawns monster at random location in Spawnpoints
        int rand = Random.Range(0, Spawnpoints.transform.childCount - 1);
        int bigOrSmall = Random.Range(0, 2);
        if (bigOrSmall == 0)
            Instantiate(lilMonsterPrefab, Spawnpoints.GetChild(rand).position, Quaternion.identity);
        else
            Instantiate(tallMonsterPrefab, Spawnpoints.GetChild(rand).position, Quaternion.identity);
    }
    public void respawnPlayer() {
        int rand = Random.Range(0, Spawnpoints.transform.childCount - 1);
        player.gameObject.transform.parent.position = Spawnpoints.GetChild(rand).position;
    }
    public void GameOver() {
        //play Sound effect "Gameover"
        speaker.PlayOneShot(Sounds[2]);
        //show score and wave #
        ShowScoreFinal();
        //return to main menu
        SceneTransition();
    }
    public void updateHealthUI() {
        //resets everything to off
        foreach (Transform heart in healthUI.transform) {
            heart.gameObject.SetActive(false);
        }
        //turn on the amount of hearts based on lives variable
        for (int i = 0; i < player.getLives(); i++) {
            healthUI.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    #region Wave Controllers
    void startNextWave() {
        //restores health to max
        player.setMaxLives();
        updateHealthUI();

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
        score++;
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
    void Awake()
    {
        speaker = GetComponent<AudioSource>();
        //player = GameObject.FindGameObjectWithTag("mainCharacter").GetComponent<PlayerStuff>();
        //if (player = null)
            //Debug.LogWarning("NO PLAYER REFERENCE");
        startNextWave();
    }
    
    void ShowScore()
    {
        scoreText.text = "" + score;
    }

    void ShowScoreFinal()
    {
        //UI Showing Final Score
    }

    void SceneTransition()
    {
        character.GetComponent<PlayerMovement>().enabled = false;
        characterModel.GetComponent<CursorFollow>().enabled = false;
        characterModel.GetComponent<PlayerStuff>().enabled = false;

        Invoke("ChangeScene", 4f);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        ShowScore();
    }
}
