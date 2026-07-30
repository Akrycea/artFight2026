using UnityEngine;
using UnityEngine.UI;

public class AutoWin : MonoBehaviour
{
    [SerializeField] private GameObject PopUp;
    [SerializeField] private static bool galleryUcovered = false;

    public void openPopUp()
    {
        if (!galleryUcovered)
        {
            PopUp.SetActive(true);
        }
    }
    public void closePopUp()
    {
        PopUp.SetActive(false);
    }
    public void autoWin()
    {
        Win();
        PopUp.SetActive(false);
        galleryUcovered = true;
    }
    public GameObject Win()
    {
        Debug.Log("doing auto win");
        // Gather all GameObjects (including inactive ones) in the scene
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            Debug.Log("found obejcts:" + obj.name);
            // Ensure the object has a SpriteRenderer component
            Image spriteRenderer = obj.GetComponent<Image>();

            // Check if the SpriteRenderer exists and if the sprite name matches
            if (spriteRenderer != null && spriteRenderer.sprite != null && obj.CompareTag("Prize"))
            {
                Debug.Log("changing color");
                spriteRenderer.color = new Color32(255, 255, 255, 255);
            }
        }

        return null; // Not found
    }
}
