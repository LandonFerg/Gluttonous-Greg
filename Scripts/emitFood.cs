using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emitFood : MonoBehaviour {

    public GameObject[] food;
    GameObject randomFood;

    public GameObject powerup;

    public obesityMeasure makeFoodFaster;      // Decreases time min/max variables as food gets faster to keep a steady flow at high speed

    float TimeMax = 3f;
    float TimeMin = 0.5f;

    float TimeFirstMin = 0.5f;
    float TimeFirstMax = 2f;

    public float random;
    public float randomFirst;

    public float randomPowerup;

    void Start ()
    {
        random = (Random.Range(TimeMin, TimeMax));

        randomFirst = (Random.Range(TimeFirstMin, TimeFirstMax));

        randomPowerup = (Random.Range(20f, 40f));       //change to 20 to 30 for debug

        randomFood = food[Random.Range(0, food.Length)];

        runFoodSpawning();      // Start coroutines
    }

    void runFoodSpawning()      // Start coroutine again
    {
        StartCoroutine(spawnFood());
    }

    void Update()
    {
        
        if (makeFoodFaster.scoreVal >= 28)      // Make food go faster at certain amount of points
        {
            Debug.Log("GOIN FASTER");

            TimeMax = 0.4f;
            TimeMin = 0.05f;

            TimeFirstMin = 0.15f;
            TimeFirstMax = 0.5f;
        }

        if (makeFoodFaster.scoreVal >= 60)      // Make food go faster at certain amount of points
        {
            Debug.Log("GOIN FASTERx2");

            TimeMax = 0.1f;
            TimeMin = 0.02f;

            TimeFirstMin = 0.02f;
            TimeFirstMax = 0.1f;
        }

        random = (Random.Range(TimeMin, TimeMax));

        randomFood = food[Random.Range(0, food.Length)];
    }

    IEnumerator spawnFood()
    {
        yield return new WaitForSeconds(randomFirst);   // The first random time to assure food doesnt spawn the same at certain height
        Instantiate(randomFood, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
        yield return new WaitForSeconds(random);
        runFoodSpawning();
    }

}
