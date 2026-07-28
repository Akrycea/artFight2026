using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Bug : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float timeToDisappear;

    [SerializeField] List<Sprite> sprites;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        timeToDisappear = Random.Range(3f, 8f);
        chooseASprite();
    }

    private void chooseASprite()
    {
        int chosenSprite = UnityEngine.Random.Range(0, sprites.Count - 1);
        spriteRenderer.sprite = sprites[chosenSprite];
    }

    void Update()
    {
        bugDies();
    }

    private void OnMouseDown()
    {
        gameManager.score++;
        Destroy(gameObject);
    }

    private void bugDies()
    {
        timeToDisappear = timeToDisappear - Time.deltaTime;

        if(timeToDisappear <= 0 || !gameManager.spawningBugs)
        {
            Destroy(gameObject);
        }
    }
}
