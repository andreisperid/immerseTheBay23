using UnityEngine;
using TMPro;

public class DrinkTextDisplay : MonoBehaviour
{
    public GameObject cylinderObject; // Reference to the cylinder
    public TextMeshPro textPrefab; //i don't want to use panel and canvas anymore, no more childTextPrefab i want to use 3d TextMeshPro directly. and position will be calculate based on cylinder pos and  height 
  

public void SetTextNextToDrinkLayers(DrinkProfile drink)
    {
        float cylinderHeight = cylinderObject.transform.localScale.y;
        float currentHeight = -1.0f;

        foreach (var layer in drink.layers)
        {
            currentHeight += (layer.percentage / 100.0f) * 2.0f; // Adjust height for each layer
            // Instantiate the TextMeshPro object
            TextMeshPro textMeshInstance = Instantiate(textPrefab, CalculatePosition(cylinderHeight, currentHeight), Quaternion.identity, transform);

            // Set the text to display the ingredient name
            textMeshInstance.text = layer.ingredientName;
        }
    }

 private Vector3 CalculatePosition(float cylinderHeight, float currentHeight)
    {
        // Calculate the position based on cylinderHeight and currentHeight
        // Adjust the logic to position the text relative to the cylinder

        float yPosition = (cylinderHeight * ((currentHeight + 1) / 2)) + cylinderObject.transform.position.y;
        Vector3 position = new Vector3(cylinderObject.transform.position.x, yPosition, cylinderObject.transform.position.z);

        return position; // Adjust the position as needed
    }

    public void SetIngredientTextSize(float height)
    {
       //TODO, I set the perfab as 0.05 now
    }
}
