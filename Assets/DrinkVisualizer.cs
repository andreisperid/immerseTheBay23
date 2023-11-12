using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DrinkLayer
{
    public Color color;
    public string ingredientName;
    public float percentage; // Percentage of the total height
}

[System.Serializable]
public class DrinkProfile
{
    public string name; // Drink name
    public List<DrinkLayer> layers;

    // Method to validate total percentage
    public bool IsValid()
    {
        float totalPercentage = 0;
        foreach (var layer in layers)
        {
            totalPercentage += layer.percentage;
        }
        return totalPercentage <= 100;
    }
}

public class DrinkVisualizer : MonoBehaviour
{
    public List<DrinkProfile> drinkProfiles;
    private Renderer _renderer;
    private Material _material;
    public GameObject canvas;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
    }

    public void VisualizeDrink(string drinkName)
    {
        DrinkProfile selectedDrink = drinkProfiles.Find(drink => drink.name == drinkName);
        if (selectedDrink != null && selectedDrink.IsValid())
        {
            float cylinderHeight = GetCylinderHeight();
            SetShaderProperties(selectedDrink, cylinderHeight);
        }
        else
        {
            Debug.LogError("Invalid drink profile or total percentage exceeds 100.");
        }
    }

    private float GetCylinderHeight()
    {
        return transform.localScale.y;
    }

    private void SetShaderProperties(DrinkProfile drink, float cylinderHeight)
{
    float currentHeight = -1.0f; // Start from the bottom of the cylinder
    float previousHeight = -1.0f;

    for (int i = 0; i < drink.layers.Count; i++)
    {
        previousHeight = currentHeight;
        // Convert the percentage to height and then map it to the range of -1 to 1
        currentHeight += (drink.layers[i].percentage / 100.0f) * 2.0f; // 2.0f is the full range from -1 to 1

        //Debug.Log($"Color[{i}] ({drink.layers[i].color}) starts at height {previousHeight} and ends at height {currentHeight}");

        // Adjust shader properties based on layer index
        switch (i)
        {
            case 0:
                _material.SetColor("_BottomColor", drink.layers[i].color);
                _material.SetFloat("_BottomHeight", currentHeight);
                break;
            case 1:
                _material.SetColor("_MiddleColor", drink.layers[i].color);
                _material.SetFloat("_MiddleHeight", currentHeight);
                break;
            case 2:
                _material.SetColor("_TopColor", drink.layers[i].color);
                _material.SetFloat("_TopHeight", currentHeight);
                break;
        }
    }
            DrinkTextDisplay drinkTextDisplay = canvas.GetComponent<DrinkTextDisplay>();
if (drinkTextDisplay != null)
{
    drinkTextDisplay.SetTextNextToDrinkLayers(drink);
    //also set size of the ingredient canvas 
    drinkTextDisplay.SetIngredientTextSize(cylinderHeight);
}
else
{
    Debug.LogError("DrinkTextDisplay component not found on the canvas");
}


}

}
