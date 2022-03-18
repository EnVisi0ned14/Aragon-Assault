using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float Speed = 20f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] float positionYawFactor = 3.65f;
    [SerializeField] float controlRollFactor = -20f;

   

    [SerializeField] GameObject[] guns;

    [SerializeField] AudioClip bulletSoundFX;


    AudioSource audioSource;


    




    float verticalThrow, horizontalThrow;

    enum State { Alive, Dead}

    State state = State.Alive;

    

    // Use this for initialization
    void Start() {
        audioSource = GetComponent<AudioSource>();

    }



    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
        Fire();
    }

    void OnPlayerDeath()
    {
        state = State.Dead;

    }
    

    private void Rotation()
    {
        if (state == State.Alive)
        {
            float pitch = transform.localPosition.y * positionPitchFactor + verticalThrow * controlPitchFactor;
            float yaw = transform.localPosition.x * positionYawFactor;
            float roll = horizontalThrow * controlRollFactor;
            transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        }
     
    }
    private void Movement()     
    {
        if (state == State.Alive)
        {
            verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
            float yOffset = verticalThrow * Time.deltaTime * Speed;
            float rawYPos = transform.localPosition.y + yOffset;
            float limitY = Mathf.Clamp(rawYPos, -6.5f, 6.5f);

            horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
            float xOffset = horizontalThrow * Time.deltaTime * Speed;
            float rawXPos = transform.localPosition.x + xOffset;
            float limitX = Mathf.Clamp(rawXPos, -10f, 10f);

            transform.localPosition = new Vector3(limitX, limitY, transform.localPosition.z);
        }
    }

    private void Fire()
    {
        if (state == State.Alive & CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
            // Play Laser Sound Effect
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(bulletSoundFX);
            }
        }
        else
        {
            SetGunsActive(false);
        }     
    }
    
    void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;

        }
    }

   
}

