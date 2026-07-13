using System.Collections;
using UnityEngine;

public class BugSpawn : MonoBehaviour
{
    [SerializeField] private GameObject bug;

    [SerializeField] private GameObject playButton;

    [SerializeField] private bool spawningBugs = false;

    [SerializeField] private float gameTimeLeft = 30f;

    [SerializeField] private float timeBetweenSpawns;

    private bool busyWithSpawning;
    void Start()
    {
        
    }

    void Update()
    {
        if (spawningBugs && !busyWithSpawning)
        {
            spawnABug();
            StartCoroutine(spawningBug());
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

}
