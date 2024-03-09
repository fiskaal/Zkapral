using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class OrthographicPlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // Adjust the speed as needed
    public float jumpForce = 8f; // Adjust the jump force as needed
    public int NumberOfCollisions = 0;
    public AudioSource w1;
    public AudioSource w2;
    public AudioSource w3;
    public AudioSource GameSound;
    public AudioSource GameMusic;
    public LayerMask groundLayer;
    public HueOnCollisionEnter hue;
    public VCamShake shakeScript;
    public CinemachineVirtualCamera cm;
    public CinemachineBasicMultiChannelPerlin perlin;
   

    private bool isGrounded;

    private void Awake()
    {
        perlin = cm.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f, groundLayer);

        // Move the player
        MovePlayer();

        

        // Make the player jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if(NumberOfCollisions == 1)
        {
            w1.Play();
        }

        if(NumberOfCollisions == 2)
        {
            w2.Play();
        }

        if(NumberOfCollisions == 3)
        {
            w3.Play();
        }
        if(NumberOfCollisions >= 4)
        {
            GameSound.Play();
            GameMusic.Play();
            NumberOfCollisions = 0;
        }
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the player in the orthographic view
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        // Apply a vertical force to simulate jumping
        GetComponent<Rigidbody>().velocity = new Vector3(0, jumpForce, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OrangeFungi") // Replace "Floor" with the tag of your floor object
        {
            if (hue.timeScale >= 0)
            {
                hue.timeScale += 25;
            }
            else
            {
                hue.timeScale = 0;
            }
            moveSpeed += 1f;

            if (shakeScript.noise.m_AmplitudeGain >= .4f) 
            {
                shakeScript.noise.m_AmplitudeGain += .1f;
            }
            if(shakeScript.noise.m_FrequencyGain >= .2f)
            {
                shakeScript.noise.m_AmplitudeGain += .1f;
            }
            
            
            


        }

        if (other.gameObject.tag == "RedFungi") // Replace "Floor" with the tag of your floor object
        {
            if (hue.timeScale >= 0)
            {
                hue.timeScale += 25;
            }
            else
            {
                hue.timeScale = 0;
            }
            moveSpeed += 1f;
            NumberOfCollisions++;
            hue.chromaScale += .1f;
        }

        if (other.gameObject.tag == "GreenFungi") // Replace "Floor" with the tag of your floor object
        {
            if (hue.timeScale >= 0)
            {
                hue.timeScale += 25;
            }
            else
            {
                hue.timeScale = 0;
            }
            moveSpeed += 1f;
            NumberOfCollisions++;

            hue.chromaScale += .1f;

        }

        if (other.gameObject.tag == "YellowFungi") // Replace "Floor" with the tag of your floor object
        {
            if(hue.timeScale >= 0)
            {
                hue.timeScale += 25;
            }
            else
            {
                hue.timeScale = 0;
            }
            if(hue.vScale >= .2f)
            {
                hue.vScale += .1f;
            }

            NumberOfCollisions = 2;
            moveSpeed += 1f;
        }

        if (other.gameObject.tag == "BrownFungi") // Replace "Floor" with the tag of your floor object
        {
            if (hue.timeScale >= 50)
            {
                hue.timeScale -= 50;
            }

            if (moveSpeed > 15)
            {
                moveSpeed -= 5f;
            }

            if (hue.vScale >= .3f)
            {
                hue.vScale -= .1f;
            }

            NumberOfCollisions--;

            hue.chromaScale -= .1f;

        }
    }
}
