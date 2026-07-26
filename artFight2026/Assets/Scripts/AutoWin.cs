using UnityEngine;
using UnityEngine.UI;

public class AutoWin : MonoBehaviour
{

    public void autoWin()
    {
        // Gather all GameObjects (including inactive ones) in the scene
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Prize");
        foreach (GameObject obj in allObjects)
        {
            // Ensure the object has a SpriteRenderer component
            Image spriteRenderer = obj.GetComponent<Image>();

            // Check if the SpriteRenderer exists and if the sprite name matches
            if (spriteRenderer != null && spriteRenderer.sprite != null)
            {
                    spriteRenderer.color = new Color32(255, 255, 255, 255);
            }
        }

        //return null; // Not found
    }
}
