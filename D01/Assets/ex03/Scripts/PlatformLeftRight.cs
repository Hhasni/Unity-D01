using UnityEngine;
using System.Collections;

public class PlatformLeftRight : MonoBehaviour {
	
	public Vector2 		my_vector;
	public float 		moveSpeed;
	// Use this for initialization
	void Start () {
		moveSpeed = 0.3f;
		my_vector = new Vector2 (1, 0);
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(my_vector * moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag != "Player")
			my_vector.x = -my_vector.x;
	}
}
