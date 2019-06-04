using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class deadGM : MonoBehaviour {

    public Text scoreTextDisplay;

    public void restartGame()
    {
        SceneManager.LoadScene("level");
    }

    void Start()
    {
        scoreTextDisplay.text = PlayerPrefs.GetInt("Score").ToString();
    }

    void Update()
    {
        if (Input.GetKey("escape"))     // Quit game
            Application.Quit();
    }
}
