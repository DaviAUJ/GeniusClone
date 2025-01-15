using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pattern : MonoBehaviour {
    public Settings Settings;

    public List<GameObject> ColorSequence = new List<GameObject>(); // List storing the order of the colors
    public GameObject[] ColorNames; // Array containing all possible colors objects
    System.Random Choice = new System.Random();

    int Score; // Score Counter
    public TMP_Text ScoreText;
    public TMP_Text RoundScoreText;

    void ToggleAllInteraction(bool ChangeColor) {
        foreach(GameObject cor in ColorNames) {
            cor.GetComponent<UnityEngine.UI.Button>().interactable = !cor.GetComponent<UnityEngine.UI.Button>().interactable; // Switch between false and true
        }
        
        // If true will change the buttons colors for displaying it is no interactable
        if(ChangeColor == true) {
            foreach(GameObject cor in ColorNames) {
                cor.GetComponent<Image>().color = new Color32(200, 200, 200, 128);
            }
        }
    }

    void AddColor() {
        ColorSequence.Add(ColorNames[Choice.Next(0, ColorNames.Length)]);
    }

    // Function responsible for animating the color order before a round
    IEnumerator BlinkOrder() {
        foreach(GameObject cor in ColorSequence) {
            ToggleAllInteraction(false);
            yield return new WaitForSeconds((float)Settings.AnimationIntervalValue); // Delay between click and animation
            cor.GetComponent<Image>().color = cor.GetComponent<UnityEngine.UI.Button>().colors.pressedColor;

            yield return new WaitForSeconds(Settings.AnimationValue); // Wait a half second and then proceed
            cor.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            ToggleAllInteraction(false);
        }

        RoundScoreText.text = "0 / " + ColorSequence.Count.ToString();
    }

    void Start() {
        AddColor(); // Adds a color to the list before the game starts
        StartCoroutine(BlinkOrder());
    }

    int ListPosition;
    // Checks if the chosen color is right and proceeds otherwise it will just end the game
    public void CheckClick(GameObject Button) {
        if(Button.name == ColorSequence[ListPosition].name) {
            ListPosition++;
            RoundScoreText.text = ListPosition.ToString() + " / " + ColorSequence.Count.ToString(); // Changes the text to the current round score

        } else {
            ScoreText.text = "Game Over"; // Changes the text to Game Over
            ToggleAllInteraction(true);
        }

        // Checks if the count got through all the list
        if(ListPosition == ColorSequence.Count) {
            // Changes the score counter
            Score++;
            ScoreText.text = Score.ToString();

            AddColor(); // Adds the next color
            StartCoroutine(BlinkOrder());

            ListPosition = 0; // Resets the counting

        }
    }
    
}
