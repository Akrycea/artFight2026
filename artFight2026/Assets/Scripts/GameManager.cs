using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject bug;

    [SerializeField] private GameObject playButton;

    [SerializeField] private bool spawningBugs = false;

    [SerializeField] private float gameTimeLeft = 30f;
    [SerializeField] private TMP_Text timeCounter;

    [SerializeField] private float timeBetweenSpawns;

    private bool busyWithSpawning;

    public int score;
    [SerializeField] private TMP_Text scoreCounter;

    void Start()
    {
        gameTimeLeft = 30;
        score = 0;
    }

    void Update()
    {
        if (spawningBugs)
        {

            gameTimeLeft = gameTimeLeft - Time.deltaTime;
            timeCounter.text = gameTimeLeft.ToString("0");

            scoreCounter.text = score.ToString();

            changingSpawnRates();

            if (!busyWithSpawning)
            {
                spawnABug();
                StartCoroutine(spawningBug());
            }

            //ends the game
            if(gameTimeLeft <= 0)
            {
                endGame();
            }
        }
    }

    //this activates after clicking "PLAY" button
    public void startSpawning()
    {
        spawningBugs = true;
        timeBetweenSpawns = 3f;
        playButton.SetActive(false);
    }

    private void spawnABug()
    {
        //randomizes spawn location
        var position = new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-4.0f, 4.0f), 0);

        Instantiate(bug, position, Quaternion.identity);
    }

    private IEnumerator spawningBug()
    {
        busyWithSpawning = true;
        yield return new WaitForSeconds(timeBetweenSpawns);
        busyWithSpawning = false;
    }

    private void changingSpawnRates()
    {
        //changing spawn rate depending on the time of the game
        if (15 < gameTimeLeft && gameTimeLeft < 20)
        {
            timeBetweenSpawns = 1f;
        }

        else if (10 < gameTimeLeft && gameTimeLeft < 15)
        {
            timeBetweenSpawns = 0.5f;
        }

        else if (5 < gameTimeLeft && gameTimeLeft < 10)
        {
            timeBetweenSpawns = 0.3f;
        }

        else if (gameTimeLeft < 5)
        {
            timeBetweenSpawns = 0.1f;
        }
    }

    private void endGame()
    {
        spawningBugs = false;
    }

}
