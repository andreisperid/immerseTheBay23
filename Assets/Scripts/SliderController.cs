using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider milkSlider;
    public Slider teaSlider;
    public Slider bobaSlider;

    private bool isAdjusting = false;

    void Start()
    {
        // Add listeners for when the value of the slider changes
        milkSlider.onValueChanged.AddListener(delegate { AdjustSliders(milkSlider); });
        teaSlider.onValueChanged.AddListener(delegate { AdjustSliders(teaSlider); });
        bobaSlider.onValueChanged.AddListener(delegate { AdjustSliders(bobaSlider); });
    }

    void AdjustSliders(Slider changedSlider)
    {
        if (isAdjusting) return;
        isAdjusting = true;

        float total = milkSlider.value + teaSlider.value + bobaSlider.value;

        // Calculate the difference to make it add up to 100%
        float diff = 100 - total;

        // Adjust the other two sliders
        if (changedSlider == milkSlider)
        {
            AdjustOtherTwoSliders(teaSlider, bobaSlider, diff);
        }
        else if (changedSlider == teaSlider)
        {
            AdjustOtherTwoSliders(milkSlider, bobaSlider, diff);
        }
        else if (changedSlider == bobaSlider)
        {
            AdjustOtherTwoSliders(milkSlider, teaSlider, diff);
        }

        isAdjusting = false;
    }

    void AdjustOtherTwoSliders(Slider first, Slider second, float diff)
    {
        float firstShare = first.value / (first.value + second.value);
        float secondShare = second.value / (first.value + second.value);

        first.value += diff * firstShare;
        second.value += diff * secondShare;
    }
}
