using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupDesigner : MonoBehaviour
{

    public GameObject placeSelector;
    public GameObject physicalCupSelector;
    public GameObject volumeSelector;
    public Transform extrudedCylinder;

    public GameObject handleSphere;
    public GameObject cup;

    public UIStateHandler uiStateHandler;

    // Start is called before the first frame update
    void Start()
    {
        placeSelector.SetActive(true);
        physicalCupSelector.SetActive(false);
        volumeSelector.SetActive(false);
        cup.SetActive(false);
    }

    public void SetPlace()
    {
        handleSphere.SetActive(false);
        placeSelector.SetActive(false);
        physicalCupSelector.SetActive(true);
    }

    public void SetPhysicalCup()
    {
        physicalCupSelector.SetActive(false);
        volumeSelector.SetActive(true);
    }

    public void SetVolume()
    {
        volumeSelector.SetActive(false);
        cup.transform.position = new Vector3(transform.position.x, transform.position.y + (extrudedCylinder.localScale.y * 0.025f), transform.position.z);
        cup.transform.localScale = extrudedCylinder.localScale * 0.025f;
        cup.SetActive(true);
        uiStateHandler.nextState();
    }

    public void SetGrab()
    {
        uiStateHandler.nextState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
