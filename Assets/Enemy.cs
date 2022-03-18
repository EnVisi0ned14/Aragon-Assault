using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] int ScorePerHit = 50;

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    [SerializeField] int healthPoints = 100;
    [SerializeField] int  damage = 20;

    ScoreBoard scoreBoard;

    int scorePerHit = 50;

	// Use this for initialization
	void Start ()
    {
        AddANonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddANonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
        
    }

    void OnParticleCollision(GameObject other)
    {
        damage = damage + 20;
        if(damage >= healthPoints)
        {
            scoreBoard.ScoreHit(scorePerHit);
            InitiateDeath();
        }


    }

    private void InitiateDeath()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
