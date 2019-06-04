using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiBug : MonoBehaviour {


    public int speed;
    GameObject strawberry;

	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        strawberry = GameObject.FindGameObjectWithTag("Powerup");
        Destroy(strawberry);

        if (transform.position.x <= 2)
        {
            Destroy(gameObject);
        }
    }

}
