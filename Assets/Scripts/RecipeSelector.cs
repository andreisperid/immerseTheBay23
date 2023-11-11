using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeSelector : MonoBehaviour
{    
    // TODO: make cup float

    //public UIStateHandler uiStateHandler;
    public GameObject prevButton;
    public GameObject nextButton;
    public GameObject [] recipeOptions;

    public int currentRecipe = 0;

    // Update is called once per frame
    void Update()
    {

        prevButton.SetActive(currentRecipe > 0);
        nextButton.SetActive(currentRecipe < recipeOptions.Length -1);


        for (int i = 0; i < recipeOptions.Length; i++)
        {
            recipeOptions[i].SetActive(currentRecipe == i);
        }       

    }

    public void Prev()
    {
        Debug.Log("prev");
        currentRecipe -= 1;
    }

    public void Next()
    {
        Debug.Log("next");
        currentRecipe += 1;
    }


}
