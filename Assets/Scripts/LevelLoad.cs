using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour {

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<LevelLoad>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
       
    }


    // Update is called once per frame
    void Update () {
		
	}

}
    