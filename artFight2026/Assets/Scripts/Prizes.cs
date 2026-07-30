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
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameManager gameManager;

    //for prize win animations
    Animator animator;
    [SerializeField] private Animator basicAnim;
    [SerializeField] private Animator SAnim;
    [SerializeField] private Animator SSAnim;

    private bool isBusyGivingPrize = false;

    [SerializeField] private GameObject gamblingGallery;
    [SerializeField] private Gallery gallery;

    //for when there are no more prizes to win
    [SerializeField] private Sprite outOfPrizes;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = ogSprite;
        animator = GetComponent<Animator>();
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

    public void exitPrizes()
    {
        gallery.fromPrizes = false;
        menuUI.SetActive(true);
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
            if (SSPrizes.Count == 0)
            {

                if (SPrizes.Count == 0)
                {
                    if (basicPrizes.Count == 0)
                    {
                        Debug.Log("no more prizes to win!");
                        spriteRenderer.sprite = outOfPrizes;
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
                        spriteRenderer.sprite = outOfPrizes;
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
                        spriteRenderer.sprite = outOfPrizes;
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
        basicAnim.Play("AuraAnimation");
    }

    private void chooseSTierPrize()
    {
        int chosenSPrize = UnityEngine.Random.Range(0, SPrizes.Count - 1);
        spriteRenderer.sprite = SPrizes[chosenSPrize];
        SPrizes.Remove(SPrizes[chosenSPrize]);
        gameManager.score = gameManager.score - 30;

        FindObjectWithSpriteName(spriteRenderer.sprite.name);
        SAnim.Play("AuraAnimation");
    }

    private void chooseSSTierPrize()
    {
        int chosenSSPrize = UnityEngine.Random.Range(0, SSPrizes.Count - 1);
        spriteRenderer.sprite = SSPrizes[chosenSSPrize];
        SSPrizes.Remove(SSPrizes[chosenSSPrize]);
        gameManager.score = gameManager.score - 30;

        FindObjectWithSpriteName(spriteRenderer.sprite.name);
        SSAnim.Play("AuraAnimation");
    }

    private IEnumerator waitToGivePrize()
    {
        animator.Play("PrizeAnimation");
        yield return new WaitForSeconds(3);
        isBusyGivingPrize = false;
        spriteRenderer.sprite = ogSprite;
        animator.Play("New State");
        basicAnim.Play("New State");
        SAnim.Play("New State");
        SSAnim.Play("New State");
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
