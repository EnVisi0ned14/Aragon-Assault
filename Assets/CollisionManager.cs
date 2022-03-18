using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour {

    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 1f;

    [SerializeField] GameObject deathFX;




    // Use this for initialization
    void Start() {

    }

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("Respawn", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");  
    }

    private void Respawn()
    {
        SceneManager.LoadScene(1);
    }
    


    // Update is called once per frame
    void Update () {
		
	}
}
