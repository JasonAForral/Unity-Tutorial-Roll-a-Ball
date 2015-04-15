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

    int scoreCount;
    int remainingPickUps;

    void Start()
    {
        scoreCount = 0;
        winText.text = "";
        UpdateScoreText();
    }

	void FixedUpdate () {
        Vector3 moveAxis = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        GetComponent<Rigidbody>().AddForce(cameraPan.TransformDirection(moveAxis * moveSpeed * Time.deltaTime));

        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(cameraPan.TransformDirection(Vector3.up * jumpSpeed), ForceMode.Impulse);
        }
        
	}
    void OnTriggerEnter(Collider other)
    {
        if ("Pick Up" == other.gameObject.tag)
        {
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject.GetComponent<Collider>());
            //Destroy(other.gameObject,1f);
            scoreCount++;
            UpdateScoreText();
            
        }
    }

    void UpdateScoreText()
    {
        remainingPickUps = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        scoreText.text = "Score: " + scoreCount;
        if (0 >= remainingPickUps)
        {
            winText.text = "You Win!";
        }
    }
}
