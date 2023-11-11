using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupDesigner : MonoBehaviour
{

    public GameObject placeSelector;
    public GameObject physicalCupSelector;
    public GameObject volumeSelector;
    public UIStateHandler uiStateHandler;


    // Start is called before the first frame update
    void Start()
    {
        placeSelector.SetActive(true);
        physicalCupSelector.SetActive(false);
        volumeSelector.SetActive(false);
    }


    public void SetPlace()
    {
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
        uiStateHandler.nextState();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
