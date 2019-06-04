using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class obesityMeasure : MonoBehaviour {

    public int scoreVal = 0;    // Score
    public Text textVal;


	void Update()
    {
        textVal.text = scoreVal.ToString();
	}
}
