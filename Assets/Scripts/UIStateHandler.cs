using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateHandler : MonoBehaviour
{

    public GameObject splash;
    public GameObject welcome;
    public GameObject select;
    public GameObject draw;
    public GameObject recipe;
    public GameObject cylinder;
    public GameObject particle;

    public float splashTime = 3.0f;
    public float welcomeTime = 5.0f;


    public enum State
    {
        Splash, Welcome, Select, Draw, Recipe, Particle
    }

    public State theState;
    private State currentState;


    // Start is called before the first frame update
    void Start()
    {
        DisableAllUI();
    }

   public void nextState()
    {
        theState += 1;
    } 

   void DisableAllUI()
    {
        splash.SetActive(false);
        welcome.SetActive(false);
        select.SetActive(false);
        draw.SetActive(false);
        recipe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != theState) DisableAllUI();

        switch (theState)
            {
            case State.Splash:
                //Debug.Log("Splash");
                splash.SetActive(true);
                splashTime -= Time.deltaTime;
                if (splashTime <= 0)
                {
                    currentState = theState;
                    theState = State.Welcome;
                }

                break;

            case State.Welcome:
                //Debug.Log("Welcome");
                welcome.SetActive(true);
                welcomeTime -= Time.deltaTime;
                if (welcomeTime <= 0)
                {
                    currentState = theState;
                    theState = State.Select;
                }
                break;

            case State.Select:
                //Debug.Log("Select");
                select.SetActive(true);
                currentState = theState;
                break;

            case State.Draw:
                //Debug.Log("Handle");
                draw.SetActive(true);
                currentState = theState;
                break;

            case State.Recipe:
                //Debug.Log("Recipe");
                recipe.SetActive(true);
                particle.SetActive(false);
                currentState = theState;
                break;

            case State.Particle:
                //Debug.Log("Recipe");
                cylinder.GetComponent<MeshRenderer>().enabled = false;
                recipe.SetActive(false);
                particle.SetActive(true);
                particle.GetComponent<SoundAndParticleController>().PlaySoundAndParticles();
                currentState = theState;
                break;
            }
        
    }
}
