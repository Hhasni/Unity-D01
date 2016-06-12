using UnityEngine;
using System.Collections;

public class SwitchPlateformScript : MonoBehaviour {

	public GameObject			obj;
	public Color				color_red;
	public Color				color_blue;
	public Color				color_yellow;
	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		//Debug.Log (coll.gameObject.tag);
		if (coll.gameObject.tag == "Player") {
			if (coll.gameObject.name == "Thomas_Red"){
				obj.GetComponent<SpriteRenderer> ().color = color_red;
				transform.gameObject.GetComponent<SpriteRenderer> ().color = color_red;
				obj.layer = 8;
			}
			if (coll.gameObject.name == "Claire_Blue"){
				obj.GetComponent<SpriteRenderer> ().color = color_blue;
				transform.gameObject.GetComponent<SpriteRenderer> ().color = color_blue;
				obj.layer = 10;
			}
			if (coll.gameObject.name == "John_Yellow"){
				obj.GetComponent<SpriteRenderer> ().color = color_yellow;
				transform.gameObject.GetComponent<SpriteRenderer> ().color = color_yellow;
				obj.layer = 13;
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
