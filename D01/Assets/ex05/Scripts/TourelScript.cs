using UnityEngine;
using System.Collections;

public class TourelScript : MonoBehaviour {

	// Use this for initialization
	public GameObject[] 		towers;
	public float				timer;
	public float				shootime;
	public GameObject			bullet;
	void Start () {
		towers = GameObject.FindGameObjectsWithTag ("Tower");
		timer = 0f;
	}
	
	void shoot () {
		foreach (GameObject tower in towers) {
			GameObject tmp = Instantiate(bullet);
			tmp.GetComponent<SpriteRenderer>().color = tower.GetComponent<SpriteRenderer>().color;
			tmp.transform.position = tower.transform.position;
			tmp.GetComponent<BulletScript>().isActive = true;
		}
	}
	// Update is called once per frame
	void Update () {
		if (timer > shootime) {
			timer = 0;
			shoot();
		}
		timer += Time.deltaTime;
	}
}
