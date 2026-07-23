using UnityEngine;

public class Gallery : MonoBehaviour
{
    [SerializeField] private GameObject PrizesUI;
    [SerializeField] private GameObject[] Pages;
    [SerializeField] private int currentPageIndex = 0;
    [SerializeField] private int totalPages = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalPages = Pages.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenGallery()
    {
        // Logic to open the gallery
        Debug.Log("Gallery opened.");

        gameObject.SetActive(true);
        PrizesUI.SetActive(false);
    }

    public void CloseGallery()
    {
        // Logic to close the gallery
        Debug.Log("Gallery closed.");

        gameObject.SetActive(false);
        PrizesUI.SetActive(true);
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
