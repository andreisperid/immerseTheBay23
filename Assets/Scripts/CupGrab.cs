using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupGrab : MonoBehaviour
{
    int numberOfCollisions = 0;

    public GameObject rightGrip;
    public GameObject leftGrip;

    GameObject currentGrip;

    // Start is called before the first frame update
    void Start()
    {

    }    


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

    void OnTriggerStay(Collider other)
    {

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
                //cupRenderer.material.SetColor("_Color", Color.red);
                transform.parent = rightGrip.transform;
            }
            else
            {
                //cupRenderer.material.SetColor("_Color", Color.green);
                transform.parent = leftGrip.transform;
            }
        }
        else
        {
            var cupRenderer = gameObject.GetComponent<Renderer>();
            transform.eulerAngles = new Vector3(0, 0, 0);
            cupRenderer.material.SetColor("_Color", Color.gray);
            transform.parent = null;
        }
    }
}
