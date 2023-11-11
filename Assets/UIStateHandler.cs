using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateHandler : MonoBehaviour
{

    public GameObject splash;
    public GameObject welcome;
    public GameObject select;
    public GameObject handle;
    public GameObject recipe;
    public GameObject done;

    public int currentState;


    public enum State
    {
        Splash, Welcome, Select, Handle, Recipe, Done
    }

    public State theState;


    // Start is called before the first frame update
    void Start()
    {
        DisableAllUI();
    }


   void DisableAllUI()
    {
        splash.SetActive(false);
        welcome.SetActive(false);
        select.SetActive(false);
        handle.SetActive(false);
        recipe.SetActive(false);
        done.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        theState = (State)currentState;


        switch (theState)
        {
            case State.Splash:
                Debug.Log("Splash");
                DisableAllUI();
                splash.SetActive(true);
                break;
            case State.Welcome:
                Debug.Log("Welcome");
                DisableAllUI();
                welcome.SetActive(true);
                break;
            case State.Select:
                Debug.Log("Select");
                DisableAllUI();
                select.SetActive(true);
                break;
            case State.Handle:
                Debug.Log("Handle");
                DisableAllUI();
                handle.SetActive(true);
                break;
            case State.Recipe:
                Debug.Log("Recipe");
                DisableAllUI();
                recipe.SetActive(true);
                break;
            case State.Done:
                Debug.Log("Done");
                DisableAllUI();
                done.SetActive(true);
                break;

        }
    }
}
