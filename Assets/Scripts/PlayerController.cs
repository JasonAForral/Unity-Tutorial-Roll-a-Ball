using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    public Transform cameraPan;
    public float moveSpeed;
    public float jumpSpeed;

    public Text scoreText;
    public Text winText;

    public AudioClip pickUpSound;
    public AudioClip jumpSound;
    public AudioClip winSound;
    AudioSource audioSource;
    Rigidbody rigidBody;

    public bool isGrounded;

    int scoreCount;
    int remainingPickUps;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
        scoreCount = 0;
        winText.text = "";
        UpdateScoreText();
    }

    void Update () 
    {
        isGrounded = Physics.Raycast(cameraPan.position, Vector3.down, 0.6f);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            audioSource.PlayOneShot(jumpSound, 0.3f);
            rigidBody.AddForce(cameraPan.TransformDirection(Vector3.up * jumpSpeed), ForceMode.Impulse);
        }
    }

	void FixedUpdate () {
        Vector3 moveAxis = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        
        rigidBody.AddForce(cameraPan.TransformDirection(moveAxis * moveSpeed * Time.deltaTime));

        
	}
    void OnTriggerEnter(Collider other)
    {
        if ("Pick Up" == other.gameObject.tag)
        {
            other.gameObject.SetActive(false);
            scoreCount++;
            audioSource.PlayOneShot(pickUpSound, 0.3f);
            UpdateScoreText();
            
        }
    }

    void UpdateScoreText()
    {
        remainingPickUps = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        scoreText.text = "Score: " + scoreCount;
        if (0 >= remainingPickUps)
        {
            audioSource.PlayOneShot(winSound, 0.3f);
            winText.text = "You Win!";
        }
    }
}
