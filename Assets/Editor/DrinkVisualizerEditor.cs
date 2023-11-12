using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(DrinkVisualizer))]
public class DrinkVisualizerEditor : Editor
{
    string drinkName = "";

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // Draw the default inspector

        DrinkVisualizer visualizer = (DrinkVisualizer)target;

        // Input field for drink name
        drinkName = EditorGUILayout.TextField("Drink Name", drinkName);

        // Button to visualize drink
        if (GUILayout.Button("Visualize Drink"))
        {
            visualizer.VisualizeDrink(drinkName);
        }
    }
}
