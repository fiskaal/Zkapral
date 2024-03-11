using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAfterDelay : MonoBehaviour
{
    public GameObject objectToActivate;

    private bool isHidden = false;

    void Start()
    {
        // Assuming the object is initially hidden, you can modify this based on your setup.
        objectToActivate.SetActive(!isHidden);

        // Call the ActivateObjectAfterDelay method after 3 seconds.
        Invoke("ActivateObjectAfterDelay", 3f);
    }

    void ActivateObjectAfterDelay()
    {
        // Check if the object is hidden before activating it.
        if (isHidden)
        {
            objectToActivate.SetActive(false);
            Debug.Log("Object activated after 3 seconds.");
        }
        else
        {
            Debug.Log("Object is not hidden. No activation needed.");
        }
    }
}
