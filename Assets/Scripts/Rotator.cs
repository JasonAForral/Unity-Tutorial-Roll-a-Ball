using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
    public Space camera;
	void Update () {
        transform.Rotate(new Vector3(15f, 30f, 45f) * Time.deltaTime);
	}
}
