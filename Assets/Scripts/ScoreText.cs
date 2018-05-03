using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    private bool ScoreSet = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!ScoreSet)
        {
            var scoreObj = GameObject.Find("ScoreHolder");

            if (scoreObj != null)
            {
                var textComponent = GetComponent<Text>();
                var scoreHolder = scoreObj.GetComponent<ScoreHolder>();
                textComponent.text = "Your Score: " + scoreHolder.Score.ToString();

                ScoreSet = true;
            }
        }
	}
}
