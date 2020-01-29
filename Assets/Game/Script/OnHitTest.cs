using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class OnHitTest : MonoBehaviour
{
    public GameObject ObjectOrientation;

    // Start is called before the first frame update
    void Start()
    {
        ObjectOrientation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHitInteractive() {
        gameObject.SetActive(false);
        ObjectOrientation.SetActive(true);
    }

    /*public void OnReset() {
        gameObject.SetActive(true);
        ObjectOrientation.SetActive(false);
    }*/

   /* 
public void OnInteractiveHitTest(HitTestResult result)
    {
        var listenerBehaviour = GetComponent<AnchorInputListenerBehaviour>();
        if (listenerBehaviour != null)
        {
            listenerBehaviour.enabled = false;
        }
    }*/
}
