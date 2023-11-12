using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupGrab : MonoBehaviour
{
    int numberOfCollisions = 0;

    List<string> collisionObjects = new List<string>();

    public GameObject rightGrip;
    public GameObject leftGrip;

    GameObject currentGrip;

    // Start is called before the first frame update
    void Start()
    {

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

        if (numberOfCollisions >= 3)
        {
            Debug.Log("grab");
            var cupRenderer = gameObject.GetComponent<Renderer>();

            if (currentGrip.tag == "RightHand") {
                cupRenderer.material.SetColor("_Color", Color.red);
                transform.parent = rightGrip.transform;
            }
            else
            {
                cupRenderer.material.SetColor("_Color", Color.green);
                transform.parent = leftGrip.transform;

            }
        }
        else
        {
            var cupRenderer = gameObject.GetComponent<Renderer>();
            cupRenderer.material.SetColor("_Color", Color.white);
            transform.parent = null;

        }

    }
}
