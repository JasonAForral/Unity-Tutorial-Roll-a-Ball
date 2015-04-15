using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    public Transform cameraPan;
    public float moveSpeed;
    public float jumpSpeed;

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
        }
    }
}
