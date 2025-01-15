using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void RunScene(string name) {
        SceneManager.LoadScene(name);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
