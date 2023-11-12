using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupGrab : MonoBehaviour
{
    int numberOfCollisions = 0;

    public GameObject rightGrip;
    public GameObject leftGrip;

    GameObject currentGrip;

    public CupDesigner cupDesigner;

    public void AdjustDimensions(float width, float height)
    {
        transform.localScale = new Vector3(width, height, width);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightHand") || other.gameObject.CompareTag("LeftHand")) { 
            if (other.gameObject == rightGrip)
            {
                currentGrip = other.gameObject;
            }
            else if (other.gameObject == leftGrip)
            {
                currentGrip = other.gameObject;
            }
            numberOfCollisions++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("RightHand") || other.gameObject.CompareTag("LeftHand"))
        {
            currentGrip = null;
            numberOfCollisions--;
        }
    }

    private void Update()
    {
        if (numberOfCollisions >= 2)
        {
            Debug.Log("grab");
            var cupRenderer = gameObject.GetComponent<Renderer>();
            cupRenderer.material.SetColor("_Color", Color.white);

            if (currentGrip.tag == "RightHand") {
                transform.parent = rightGrip.transform;
            }
            else
            {
                transform.parent = leftGrip.transform;
            }
            cupDesigner.SetGrab();
        }
    }
}
