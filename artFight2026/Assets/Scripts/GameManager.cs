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

    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject gamblingGallery;

    void Start()
    {
        gameTimeLeft = 30;
        score = 0;
    }

    void Update()
    {

        scoreCounter.text = score.ToString();

        if (spawningBugs)
        {

            gameTimeLeft = gameTimeLeft - Time.deltaTime;
            timeCounter.text = gameTimeLeft.ToString("0");


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
        gameUI.SetActive(true);
        gameTimeLeft = 30;
        spawningBugs = true;
        timeBetweenSpawns = 1.8f;
        playButton.SetActive(false);
    }

    private void spawnABug()
    {
        //randomizes spawn location
        var position = new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 3.05f), 0);

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
        if (18 < gameTimeLeft && gameTimeLeft < 26)
        {
            timeBetweenSpawns = 1f;
        }

        else if (10 < gameTimeLeft && gameTimeLeft < 18)
        {
            timeBetweenSpawns = 0.5f;
        }

        else if (7 < gameTimeLeft && gameTimeLeft < 10)
        {
            timeBetweenSpawns = 0.4f;
        }

        else if (gameTimeLeft < 7)
        {
            timeBetweenSpawns = 0.35f;
        }
    }

    private void endGame()
    {
        spawningBugs = false;
        gameUI.SetActive(false);
        gamblingGallery.SetActive(true);
    }

}
