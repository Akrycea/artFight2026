using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Bug : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private float minDistance = 1f;
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private Vector2 targetPosition;
    [SerializeField] private float t = 0;

    [SerializeField] private float timeBetweenChangingDirection = 1f;
    private bool canMove;

    [SerializeField] private float timeToDisappear;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        timeToDisappear = Random.Range(3f, 8f);
        canMove = true;
    }


    void Update()
    {
        if (canMove)
        {
            // save it current rotation
            Quaternion rotation = transform.rotation;
            // Spin it around a random amount
            transform.Rotate(Vector3.forward, Random.Range(0, 360));
            // move it a random amount forward based on it current facing
            transform.position += transform.up * Random.Range(minDistance, maxDistance);
            // put it back to its original rotation
            transform.rotation = rotation;
            StartCoroutine(wait());
        }

        bugDies();
    }

    private IEnumerator wait()
    {
        canMove = false;
        yield return new WaitForSeconds(timeBetweenChangingDirection);
        canMove = true;
    }

    private void OnMouseDown()
    {
        gameManager.score++;
        gameObject.SetActive(false);
    }

    private void bugDies()
    {
        timeToDisappear = timeToDisappear - Time.deltaTime;

        if(timeToDisappear <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
