using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {
	
	public GameObject obj1;
	public GameObject obj2;
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log (col.gameObject.tag);
		if (col.gameObject.tag == "Player"){
			obj1.transform.position = new Vector2(obj1.transform.position.x , -0.6f);
			obj2.transform.position = new Vector2(obj2.transform.position.x , -0.6f);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
