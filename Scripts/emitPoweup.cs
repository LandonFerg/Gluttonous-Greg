using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emitPoweup : MonoBehaviour {

    public float randomPowerup;

    public GameObject powerup;

    void Start ()
    {
        Random.InitState(42);
        runPowerup();
    }

    void runPowerup()      // Start coroutine again
    {
        StartCoroutine(spawnPowerup());
    }

    void Update()
    {
        randomPowerup = (Random.Range(10f, 30f));       //change to 20 to 30 for debug
    }


    IEnumerator spawnPowerup()
    {
        yield return new WaitForSeconds(randomPowerup);         // Spawn powerup 30 to 50 seconds apart
        Instantiate(powerup, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
        runPowerup();
    }
}
