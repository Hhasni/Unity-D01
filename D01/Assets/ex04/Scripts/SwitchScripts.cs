using UnityEngine;
using System.Collections;

public class SwitchScripts : MonoBehaviour {
	
	public GameObject[] 		Items;
	public Color				color_red;
	public Color				color_blue;
	public Color				color_yellow;
	public bool 				my_bool;
	public string 				DoorName;

	// Use this for initialization
	void Start () {
		my_bool = false;
		Items = new GameObject[0];
	//	color_red = new Color (214.0f, 69.0f, 66.0f);
	//	color_blue = new Color (37.0f, 61.0f, 95.0f);
	//	color_yellow = new Color (180.0f, 156.0f, 56.0f);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		//Debug.Log (coll.gameObject.tag);
		if (coll.gameObject.tag == "Player") {
			my_bool = true;
			transform.gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			if (coll.gameObject.name == "Thomas_Red")
			{
				Items = GameObject.FindGameObjectsWithTag ("Red_Door");
				transform.gameObject.GetComponent<SpriteRenderer> ().color = color_red;
			}
			if (coll.gameObject.name == "Claire_Blue")
			{
				Items = GameObject.FindGameObjectsWithTag ("Blue_Door");
				transform.gameObject.GetComponent<SpriteRenderer> ().color = color_blue;
			}
			if (coll.gameObject.name == "John_Yellow")
			{
				Items = GameObject.FindGameObjectsWithTag ("Yellow_Door");
				transform.gameObject.GetComponent<SpriteRenderer> ().color = color_yellow;
			}
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		my_bool = false;
		transform.gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
	}

	// Update is called once per frame
	void Update () {
		if (my_bool == true) {
			foreach (GameObject item in Items) {
				if (item.gameObject.GetComponent<SpriteRenderer> ().color == transform.gameObject.GetComponent<SpriteRenderer> ().color)
					item.gameObject.GetComponent<DoorScriptUpDown> ().GoUp ();
			}
		} else {
			if (Items.Length > 0) {
				foreach (GameObject item in Items){
					item.gameObject.GetComponent<DoorScriptUpDown> ().GoDown ();
					if (item.gameObject.GetComponent<DoorScriptUpDown> ().stop == true)
						Items = new GameObject[0];
				}
			}
		}
	}
}
