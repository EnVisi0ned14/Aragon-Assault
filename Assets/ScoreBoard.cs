using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {



    float score = 0;
    float timeAliveFactor = 5f;
    Text scoreText;
    float time = 0;
    

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
	}

    void Update() 
    {
        ScoreIncrease();
    }

    public void ScoreHit(int scorePerHit)
    {
        score = score + scorePerHit;
        scoreText.text = score.ToString();
    }

    public void ScoreIncrease()
    {
        time = time + .0001f;
        score = score + time;
        scoreText.text = score.ToString();

    }
    
}
