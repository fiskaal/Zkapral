using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

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
    public AudioSource pickup1;
    public AudioSource pickup2;
    public AudioSource pickup3;
    public GameObject blackCanvas;
    public GameObject whiteCanvas;
    public LayerMask groundLayer;
    public HueOnCollisionEnter hue;
    public VCamShake shakeScript;
    public CinemachineVirtualCamera cm;
    public CinemachineBasicMultiChannelPerlin perlin;
    public int collectedMushrooms = 0;
    
    public TextMeshProUGUI scoreText;
    public GameObject whiteFungus;
    public GameObject blackFungus;
    public GameObject pauseMenu;



    private bool isGrounded;

    private void Awake()
    {
        perlin = cm.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        

        shakeScript.noise.m_AmplitudeGain = .4f;
        shakeScript.noise.m_FrequencyGain = .2f;
        shakeScript.target.m_Damping = 2f;
        Time.timeScale = 1;
        collectedMushrooms = 0;
        blackFungus.SetActive(false);
        whiteFungus.SetActive(true);

    }
    private void Start()
    {
        UpdateScoreText();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f, groundLayer);

        // Move the player
        MovePlayer();

        if(collectedMushrooms >= 40)
        {
            blackFungus.SetActive(true);
            whiteFungus.SetActive(false);
        }
        else
        {
            blackFungus.SetActive(false);
            whiteFungus.SetActive(true);

        }
        if (Input.GetButtonDown("Escape"))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }



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

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "" + collectedMushrooms;
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

            other.gameObject.SetActive(false);

            pickup1.Play();
            collectedMushrooms++;
            UpdateScoreText();
            NumberOfCollisions++;




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

            if (shakeScript.noise.m_FrequencyGain >= .2f)
            {
                shakeScript.noise.m_FrequencyGain += .1f;
            }

            moveSpeed += 1f;
            NumberOfCollisions++;
            hue.chromaScale += .1f;
            pickup2.Play();
            other.gameObject.SetActive(false);
            collectedMushrooms++;
            UpdateScoreText();
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
            shakeScript.target.m_Damping += 1f;
            pickup3.Play();
            other.gameObject.SetActive(false);
            collectedMushrooms++;
            UpdateScoreText();

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
            if(NumberOfCollisions <= 2)
            {
                NumberOfCollisions++;
            }
            else
            {
                NumberOfCollisions = 1;
            }

            
            moveSpeed += 1f;
            pickup1.Play();
            other.gameObject.SetActive(false);
            collectedMushrooms++;
            UpdateScoreText();
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
            pickup2.Play();
            other.gameObject.SetActive(false);
            collectedMushrooms++;
            UpdateScoreText();

        }

        if (other.gameObject.tag == "WhiteFungi") // Replace "Floor" with the tag of your floor object
        {
            hue.timeScale = 0f;


            moveSpeed = 10f;


            hue.vScale = .3f;


            NumberOfCollisions = 0; ;

            hue.chromaScale = 0f;

            shakeScript.noise.m_FrequencyGain = .2f;
            shakeScript.noise.m_AmplitudeGain = .4f;
            shakeScript.target.m_Damping = 3f;
            pickup3.Play();
            Time.timeScale = 0;
            whiteCanvas.SetActive(true);
            other.gameObject.SetActive(false);
            collectedMushrooms++;
        }

        if(other.gameObject.tag == "BlackFungi")
        {
            hue.vScale = 100;
            moveSpeed = 100f;
            hue.timeScale = 1000f;
            hue.chromaScale = 100f;
            shakeScript.noise.m_FrequencyGain = 20f;
            shakeScript.noise.m_AmplitudeGain = 40f;
            shakeScript.target.m_Damping = 30f;
            pickup1.Play();
            Time.timeScale = 0;
            blackCanvas.SetActive(true);
            other.gameObject.SetActive(false);
            collectedMushrooms++;

        }
    }
}
