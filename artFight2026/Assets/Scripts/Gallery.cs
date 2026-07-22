using UnityEngine;

public class Gallery : MonoBehaviour
{
    [SerializeField] private GameObject PrizesUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
}
