using UnityEngine;

public class Gallery : MonoBehaviour
{
    [SerializeField] private GameObject PrizesUI;
    [SerializeField] private GameObject MenuUI;
    [SerializeField] private GameObject GameUI;
    [SerializeField] private GameObject[] Pages;
    [SerializeField] private int currentPageIndex = 0;
    [SerializeField] private int totalPages = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalPages = Pages.Length;
    }

    public bool fromPrizes = false;
    private bool fromMenu = false;
    public void OpenGallery()
    {
        // Logic to open the gallery
        Debug.Log("Gallery opened.");

        gameObject.SetActive(true);
        PrizesUI.SetActive(false);

        if(fromPrizes == true)
        {
            Debug.Log("prize is active");
            gameObject.SetActive(true);
            PrizesUI.SetActive(false);
            GameUI.SetActive(false);
        }
        else
        {
            Debug.Log("menu is active");
            gameObject.SetActive(true);
            MenuUI.SetActive(false);
            GameUI.SetActive(false);
            fromMenu =true;
        }
    }

    public void CloseGallery()
    {
        // Logic to close the gallery
        Debug.Log("Gallery closed.");

        if (fromPrizes)
        {
            gameObject.SetActive(false);
            PrizesUI.SetActive(true);
        }
        else if (fromMenu)
        {
            gameObject.SetActive(false);
            MenuUI.SetActive(true);
            fromMenu =false;
        }
    }


    public void LeftPage()
    {
        Pages[currentPageIndex].SetActive(false);
        currentPageIndex--;

        if (currentPageIndex < 0)
        {
            currentPageIndex = totalPages - 1; // Wrap around to the last page
        }

        Pages[currentPageIndex].SetActive(true);
    }

    public void RightPage()
    {
        Pages[currentPageIndex].SetActive(false);
        currentPageIndex++;

        if (currentPageIndex >= totalPages)
        {
            currentPageIndex = 0; // Wrap around to the first page     
        }

        Pages[currentPageIndex].SetActive(true);
    }
}
