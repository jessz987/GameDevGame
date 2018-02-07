using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerControl : MonoBehaviour {

    public GameObject topScoop;
    public GameObject cone;

    public int score = 0;
    public float gameTime;

    public Text scoreText;
    public Text gameTimeText;

    // Use this for initialization
    void Start () {
        topScoop = cone;
	}
	
	// Update is called once per frame
	void Update () {
        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
        {
            Time.timeScale = 0; // freezes the game
        }

        UpdateUI();
	}

    void UpdateUI()
    {
        scoreText.text = score.ToString(); //converts to a string
        gameTimeText.text = gameTime.ToString("F0"); //F_ for how many decimal places, in this case 0
    }
}
