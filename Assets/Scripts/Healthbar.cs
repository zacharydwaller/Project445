using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    GameManager gameManager;
    Slider bar;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bar = GetComponent<Slider>();
        bar.maxValue = GameManager.MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        bar.value = gameManager.Health;
	}
}
