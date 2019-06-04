using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour {


    public Image life1;
    public Image life2;
    public Image life3;

    public charControl charScripty;
    

	void Update ()
    {

        if (Input.GetKey("escape"))     // Quit game
            Application.Quit();

        if (charScripty.lives == 3)
        {
            life3.gameObject.SetActive(true);
            life2.gameObject.SetActive(true);
            life1.gameObject.SetActive(true);
        }

        if (charScripty.lives == 2 )
        {
            life3.gameObject.SetActive(false);
            life2.gameObject.SetActive(true);
            life1.gameObject.SetActive(true);
        }

        else if (charScripty.lives == 1 )
        {
            life3.gameObject.SetActive(false);
            life2.gameObject.SetActive(false);
            life1.gameObject.SetActive(true);
        }

        else if (charScripty.lives == 0 )
        {
            life3.gameObject.SetActive(false);
            life2.gameObject.SetActive(false);
            life1.gameObject.SetActive(false);
        }
    }
}
