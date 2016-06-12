using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	// Use this for initialization
	public GameObject[] 		objs;
	void Start () {
		objs = GameObject.FindGameObjectsWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject obj in objs) {
			if (obj.transform.position.y < -20){
				//Debug.Log("GAME OVER");
				Application.LoadLevel(0);
			}
		}
	
	}
}
