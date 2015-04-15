using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    public Transform cameraPan;
    public float moveSpeed;

	void FixedUpdate () {
        Vector3 moveAxis = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        GetComponent<Rigidbody>().AddForce(cameraPan.TransformDirection(moveAxis * moveSpeed * Time.deltaTime));
        
	}
}
