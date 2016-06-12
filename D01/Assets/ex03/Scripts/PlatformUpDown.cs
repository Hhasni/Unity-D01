using UnityEngine;
using System.Collections;

public class PlatformUpDown : MonoBehaviour {

	public Vector2 		velocity;
	public Vector2 		my_vector;
	public float 		moveSpeed;
	public float 		minY;
	public float 		maxY;
	// Use this for initialization
	void Start () {
	//	minY = - 2.28f;
	//	maxY = 1.50f;
		moveSpeed = 0.3f;
		my_vector = new Vector2 (0, 1);
	}
	
//	void OnCollisionEnter2D(Collision2D coll) {
//		Debug.Log ("Collision with = ");
//	}
//	
//	void OnTriggerEnter2D(Collider2D col) {
//		if (col.gameObject.tag != "Player")
//			my_vector.y = -my_vector.y;
//	}

	void ft_check_y (){
		if  (transform.position.y < minY)
			my_vector.y = -my_vector.y;
		if  (transform.position.y > maxY)
			my_vector.y = -my_vector.y;
	}

	// Update is called once per frame
	void Update () {
		ft_check_y ();
		transform.Translate(my_vector * moveSpeed * Time.deltaTime);
	}
}