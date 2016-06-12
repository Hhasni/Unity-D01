using UnityEngine;
using System.Collections;

public class CameraScript_ex01 : MonoBehaviour {

	public GameObject target;
	public float xOffset;
	public float yOffset;
	public float zOffset;
	public Vector3 velocity;
	public float dampTime;
	

	// Use this for initialization
	void Start () {
		dampTime = 0.5f;
	}

	void LateUpdate() {
		if (target.transform.position.y > -15) {
			Vector3 destination = target.transform.position;
			destination.z = transform.position.z;
			transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
		}
	}
	// Update is called once per frame
	void Update () {
	}
}
