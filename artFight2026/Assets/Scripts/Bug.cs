using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Bug : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    //[SerializeField] private float minDistance = 1f;
    //[SerializeField] private float maxDistance = 5f;
    //[SerializeField] private Vector2 targetPosition;
    //[SerializeField] private float t = 0;

    //[SerializeField] private float timeBetweenChangingDirection = 1f;
    //private bool canMove;

    [SerializeField] private float timeToDisappear;

    [SerializeField] List<Sprite> sprites;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        timeToDisappear = Random.Range(3f, 8f);
        //canMove = true;
        chooseASprite();
    }

    private void chooseASprite()
    {
        int chosenSprite = UnityEngine.Random.Range(0, sprites.Count - 1);
        spriteRenderer.sprite = sprites[chosenSprite];
    }

    void Update()
    {
        //if (canMove)
        //{
        //    // save it current rotation
        //    Quaternion rotation = transform.rotation;
        //    // Spin it around a random amount
        //    transform.Rotate(Vector3.forward, Random.Range(0, 360));
        //    // move it a random amount forward based on it current facing
        //    transform.position += transform.up * Random.Range(minDistance, maxDistance);
        //    // put it back to its original rotation
        //    transform.rotation = rotation;
        //    StartCoroutine(wait());
        //}

        bugDies();
    }

    //private IEnumerator wait()
    //{
    //    canMove = false;
    //    yield return new WaitForSeconds(timeBetweenChangingDirection);
    //    canMove = true;
    //}

    private void OnMouseDown()
    {
        gameManager.score++;
        Destroy(gameObject);
    }

    private void bugDies()
    {
        timeToDisappear = timeToDisappear - Time.deltaTime;

        if(timeToDisappear <= 0)
        {
            Destroy(gameObject);
        }
    }
}
