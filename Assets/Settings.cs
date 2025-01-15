using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Settings : MonoBehaviour {
    public GameObject AnimationSlider;
    public GameObject ValueBox;
    TMP_InputField BoxInputField;
    Slider Slider;

    public static float AnimationValue = 0.5f;
    public static double AnimationIntervalValue = 0.75f;

    void Start() {
        BoxInputField = ValueBox.GetComponent<TMP_InputField>();
        Slider = AnimationSlider.GetComponent<Slider>();

    }

    // Used on the toggle in the settings menu
    public void ToggleInputField(GameObject Field) {
        if(Field.activeSelf) {
            Field.SetActive(false);
        } else {
            Field.SetActive(true);
        }
    }

    public void setAnimationSpeedOnSlideField(float Value) {
        ValueBox.GetComponent<TMP_InputField>().text = Value.ToString("F1");
        AnimationValue = Value;
        AnimationIntervalValue = Math.Round((-0.44f * AnimationValue * AnimationValue) + (1.639f * AnimationValue) + 0.041f, 2, MidpointRounding.AwayFromZero);
    }

    public void setAnimationSpeedOnInputField(string Value) {
        float ValueFloat = float.Parse(Value);

        // Corrects the value if it is incorrect
        if(ValueFloat > 3) {
            ValueFloat = 3;
        } else if(ValueFloat < 0.1f) {
            ValueFloat = 0.1f;
        }

        Slider.value = ValueFloat;
        AnimationValue = ValueFloat;
        AnimationIntervalValue = Math.Round((-0.44f * AnimationValue * AnimationValue) + (1.639f * AnimationValue) + 0.041f, 2, MidpointRounding.AwayFromZero);
    }
}