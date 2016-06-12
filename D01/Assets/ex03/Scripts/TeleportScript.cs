using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {
	
	public GameObject Out;

	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log ("Collision with = " + col.tag + " / " + col.name);
		if (col.tag == "Player"){
			col.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,0);
			col.gameObject.GetComponent<playerScript_ex01> ().touchGround = false;
			col.gameObject.transform.position = Out.transform.position;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
