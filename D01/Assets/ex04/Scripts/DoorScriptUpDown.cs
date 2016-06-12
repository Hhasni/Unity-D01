using UnityEngine;
using System.Collections;

public class DoorScriptUpDown : MonoBehaviour {

	public float		MaxY;
	public float		MinY;
	public bool 		stop;

	// Use this for initialization
	void Start () {
		stop = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
//	void OnCollisionEnter2D(Collision2D col){
//		Debug.Log (col.gameObject.tag);
//		if (col.gameObject.tag == "ground")
//			stop = true;
//	}
	//
//	void OnCollisionExit2D(Collision2D col){
//		if (col.gameObject.tag == "ground")
//			stop = false;
//	}

	public void GoUp () {
		stop = false;
		if (transform.position.y < MaxY)
			transform.Translate (Vector2.up * Time.deltaTime);
	}

	public void GoDown () {
		if (transform.position.y > MinY)
			transform.Translate (-Vector2.up * Time.deltaTime);
		if (transform.position.y <= MinY)
			stop = true;
	}
}
