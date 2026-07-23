using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Prizes : MonoBehaviour
{
    [SerializeField] List<Sprite> basicPrizes;
    [SerializeField] List<Sprite> SPrizes;
    [SerializeField] List<Sprite> SSPrizes;

    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite ogSprite;

    [SerializeField] private Button gamblingButton;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject prizes;

    private bool isBusyGivingPrize = false;

    [SerializeField] private GameObject gamblingGallery;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = ogSprite;
                playButton.SetActive(true);
        gamblingGallery.SetActive(false);
    }


    void Update()
    {
        if (gameManager.score >= 30 && !isBusyGivingPrize)
        {
            gamblingButton.enabled = true;
        }
        else
        {
            gamblingButton.enabled = false;
        }
    }

    public void exitGallery()
    {
        playButton.SetActive(true);
        gamblingGallery.SetActive(false);
    }
    public void Gamble()
    {
        choosePrizeTier();
        isBusyGivingPrize = true;
    }

    //jakis tu bullshit odprawilam dw babygirl
    private void choosePrizeTier()
    {
        int chosenTier = UnityEngine.Random.Range(0, 10);
        if (chosenTier == 0 || chosenTier == 1)
        {
            //if (SSPrizes.Count - 1 != -1)
            //{
            //    chooseSSTierPrize();
            //}
            //else if (SPrizes.Count - 1 != -1)
            //{
            //    chooseSTierPrize();
            //}
            //else if (basicPrizes.Count - 1 != -1)
            //{
            //    chooseBasicPrize();
            //}
            //else if (basicPrizes.Count - 1 == -1 && basicPrizes.Count - 1 == -1 && basicPrizes.Count - 1 == -1)
            //{
            //    Debug.Log("no more prizes to win!");
            //}

            if (SSPrizes.Count == 0)
            {

                if (SPrizes.Count == 0)
                {
                    if (basicPrizes.Count == 0)
                    {
                        Debug.Log("no more prizes to win!");
                    }
                    else
                    {
                        chooseBasicPrize();
                    }
                }
                else
                {
                    chooseSTierPrize();
                }
            }
            else
            {
                chooseSSTierPrize();
            }
        }
        else if (2 == chosenTier || chosenTier == 3 || chosenTier == 4)
        {

            if (SPrizes.Count == 0)
            {
                if (SSPrizes.Count == 0)
                {
                    if (basicPrizes.Count == 0)
                    {
                        Debug.Log("no more prizes to win!");
                    }
                    else
                    {
                        chooseBasicPrize();
                    }
                }
                else
                {
                    chooseSSTierPrize();
                }
            }
            else
            {
                chooseSTierPrize();
            }
        }
        else if (5 <= chosenTier)
        {
            if (basicPrizes.Count == 0)
            {
                if (SPrizes.Count == 0)
                {
                    if (SSPrizes.Count == 0)
                    {
                        Debug.Log("no more prizes to win!");
                    }
                    else
                    {
                        chooseSSTierPrize();
                    }
                }
                else
                {
                    chooseSTierPrize();
                }
            }
            else
            {
                chooseBasicPrize();
            }

        }

        StartCoroutine(waitToGivePrize());
    }

    private void chooseBasicPrize()
    {
        int chosenBasicPrize = UnityEngine.Random.Range(0, basicPrizes.Count - 1);
        spriteRenderer.sprite = basicPrizes[chosenBasicPrize];
        basicPrizes.Remove(basicPrizes[chosenBasicPrize]);
        gameManager.score = gameManager.score - 30;

        FindObjectWithSpriteName(spriteRenderer.sprite.name);

        //here we can do whatever we want with the chosen prize
        //change prizes gallery bool to show this one
    }

    private void chooseSTierPrize()
    {
        int chosenSPrize = UnityEngine.Random.Range(0, SPrizes.Count - 1);
        spriteRenderer.sprite = SPrizes[chosenSPrize];
        SPrizes.Remove(SPrizes[chosenSPrize]);
        gameManager.score = gameManager.score - 30;

        FindObjectWithSpriteName(spriteRenderer.sprite.name);

        //here we can do whatever we want with the chosen prize
        //change prizes gallery bool to show this one
    }

    private void chooseSSTierPrize()
    {
        int chosenSSPrize = UnityEngine.Random.Range(0, SSPrizes.Count - 1);
        spriteRenderer.sprite = SSPrizes[chosenSSPrize];
        SSPrizes.Remove(SSPrizes[chosenSSPrize]);
        gameManager.score = gameManager.score - 30;

        FindObjectWithSpriteName(spriteRenderer.sprite.name);

        //here we can do whatever we want with the chosen prize
        //change prizes gallery bool to show this one
    }

    private IEnumerator waitToGivePrize()
    {
        yield return new WaitForSeconds(3);
        isBusyGivingPrize = false;
        spriteRenderer.sprite = ogSprite;
    }



    public GameObject FindObjectWithSpriteName(string targetSpriteName)
    {
        // Gather all GameObjects (including inactive ones) in the scene
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // Ensure the object has a SpriteRenderer component
            Image spriteRenderer = obj.GetComponent<Image>();

            // Check if the SpriteRenderer exists and if the sprite name matches
            if (spriteRenderer != null && spriteRenderer.sprite != null)
            {
                if (spriteRenderer.sprite.name == targetSpriteName)
                {
                    spriteRenderer.color = new Color32(255, 255, 255, 255);
                }
            }
        }

        return null; // Not found
    }


}
