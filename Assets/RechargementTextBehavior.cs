using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargementTextBehavior : MonoBehaviour
{

    public void ShowMessage()
    {
        gameObject.SetActive(true);
        StartCoroutine(HideAfterDelay());
    }

    public void HideMessage()
    {
        gameObject.SetActive(false);
    }
    IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    
}
