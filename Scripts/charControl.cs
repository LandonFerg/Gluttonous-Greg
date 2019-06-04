using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class charControl : MonoBehaviour {

    public Rigidbody charCollide;

    public float control;
    public bool jump;
    public float jumpHeight = 10f;
    public float currentSpeed = 40f;
    public float speed = 30f;

    public obesityMeasure scoreScript;

    public int scores;


    public float foodDropSpeed = 3f;    // Drop speed of food

    Animator animate;


    public int lives = 3;
    public float maxSpeed = 40f;
    Collider coll;

    public float distToGround;

    public AudioSource Nom;

	// Use this for initialization
	void Start ()
    {
        Nom = GetComponent<AudioSource>();

        animate = gameObject.GetComponent<Animator>();
        charCollide = GetComponent<Rigidbody>();

        coll = gameObject.GetComponent<CapsuleCollider>();      // Chnage to capsule to whatever coll later

        distToGround = coll.bounds.extents.y;
    }

    bool isGrounded()
    {
        // Call GroundCheck
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        scores = scoreScript.scoreVal;

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        if (lives >= 3)
        {
            lives = 3;
        }

        if (lives <= 0)
        {
            Debug.Log("you died! :(");      // Play sound transfer to death screen etc


            scoreScript.scoreVal = scores;

            PlayerPrefs.SetInt("Score", scores);        // Save score value
            SceneManager.LoadScene("level2");
        }
        if (speed == maxSpeed)
        {
            speed--;
        }

        control = Input.GetAxisRaw("Horizontal") * currentSpeed * -1;

        if (control < 0)     // going right
        {
            animate.SetBool("Moving", true);        // play walk anim
            transform.eulerAngles = new Vector2(0, -90);    // Flip char 180
        }

        if (control > 0)     // going left
        {
            animate.SetBool("Moving", true);        // play walk anim

            transform.eulerAngles = new Vector2(0, 90);    // Flip char 180
        }
        else if (control == 0) { animate.SetBool("Moving", false); }



        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            charCollide.velocity = new Vector3(0, 10, 0);
        }

        if (isGrounded() == false)      // If you're off the ground, set speed to slower
        {
            currentSpeed = 7;
        }
        else
        {
            currentSpeed = speed;
        }

        charCollide.AddForce(control, 0, 0);


    }

}
