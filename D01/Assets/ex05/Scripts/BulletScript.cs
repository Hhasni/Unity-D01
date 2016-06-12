using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float 		moveSpeed;
	public bool 		isActive;
	public Color 		color_red;
	public Color 		color_blue;
	public Color 		color_yellow;
	// Use this for initialization
	void Start () {
		moveSpeed = 1;
	}

	void GameOver (){
		Debug.Log ("GameOver");
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			//Debug.Log ("Player");
			if (coll.gameObject.name == "Thomas_Red" && gameObject.GetComponent<SpriteRenderer> ().color == color_red)
				GameOver ();
			if (coll.gameObject.name == "Claire_Blue" && gameObject.GetComponent<SpriteRenderer> ().color == color_blue)
				GameOver ();
			if (coll.gameObject.name == "John_Yellow" && gameObject.GetComponent<SpriteRenderer> ().color == color_yellow)
				GameOver ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive == true) {
			if (transform.position.y < -5)
				Destroy (gameObject);
			if (transform.position.y > 8)
				Destroy (gameObject);
			transform.Translate (transform.up * moveSpeed * Time.deltaTime);
		}
	}
}
