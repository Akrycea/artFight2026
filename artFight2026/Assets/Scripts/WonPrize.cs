using System.Collections;
using UnityEngine;

public class WonPrize : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(waitingToDie());
        }
    }

    private IEnumerator waitingToDie()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
