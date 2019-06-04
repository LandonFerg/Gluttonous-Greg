using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour {

    public float speed;        // How fast the food goes dowm
    public float rotSpeed;
    obesityMeasure displayPoints;
    charControl charScript;

    public GameObject particleDie;
    public GameObject particleHeal;
    public GameObject particleBurg;
    public GameObject particlePower;

    public Image life1;
    public Image life2;
    public Image life3;


    void Start ()
    {
        rotSpeed = 60f;
        charScript = GameObject.FindGameObjectWithTag("player").GetComponent<charControl>();

        displayPoints = GameObject.Find("obesityText").GetComponent<obesityMeasure>();
        speed = charScript.foodDropSpeed;
    }
	

	void Update ()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        transform.Rotate(Vector3.down * (rotSpeed * Time.deltaTime));

        if (gameObject.transform.position.y < 1.62)     // delete food if too low
        {
            Instantiate(particleDie, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);    // Spawn particles
            gameObject.SetActive(false);
        }
	}

    // Collisions

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player" && gameObject.tag == "Healthy")
        {
            Instantiate(particleHeal, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);   // spawn particles
            displayPoints.scoreVal++;
            gameObject.SetActive(false);           // Destroy object when eaten
            charScript.speed++;
            charScript.foodDropSpeed = charScript.foodDropSpeed + 0.15f;

            charScript.Nom.Play();
            charScript.Nom.pitch = (Random.Range(0.7f, 1.2f));  // Play sound
        }

        else if (other.gameObject.tag == "player" && gameObject.tag == "Burger")        // If powerup is off
        {
            Instantiate(particleBurg, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);   // spawn particles
            gameObject.SetActive(false);    // Destroy object when eaten
            charScript.speed = charScript.speed - 8;
            charScript.lives--;
            charScript.foodDropSpeed = charScript.foodDropSpeed - 0.5f;
            speed--;

            charScript.Nom.Play();
            charScript.Nom.pitch = (Random.Range(0.75f, 1.3f));
        }


        else if (other.gameObject.tag == "player" && gameObject.tag == "Powerup")       // Blue strawberry
        {
            Instantiate(particlePower, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);   // spawn particles
            gameObject.SetActive(false);            // Destroy object when eaten
            charScript.speed = charScript.speed + 20;

            displayPoints.scoreVal = displayPoints.scoreVal + 5;

            charScript.lives++;
            charScript.Nom.Play();
            charScript.Nom.pitch = (Random.Range(0.75f, 1.3f));     // Play powerup noise
        }

    }
}