using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			//Debug.Log ("GAME OVER");
			Application.LoadLevel (0);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
