using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform cameraTilt;
    public Transform cameraZoom;

    public Transform playerTransform;
    
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position;
	}

    void Update() {
        if (Input.GetMouseButton(2))
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X"));
            cameraTilt.Rotate(Vector3.left * Input.GetAxis("Mouse Y"));
        }
    }

    // Update is called once per frame
	void LateUpdate () {
        transform.position = playerTransform.position;
	}
}
