using UnityEngine;
using System.Collections;

public class playerScript_ex01 : MonoBehaviour {
	
	public GameObject	Thomas;
	public GameObject	Claire;
	public GameObject	John;
	public GameObject	CurrentObj;
	public int 			Finish;
	public float		moveSpeed;
	public float		JumpSpeed;
	public float 		jumpTime;
	public float 		timer;
	public Vector2 		rayDistance;
	public bool 		touchGround;
	public bool 		win;
	public Rigidbody2D 	playerRigidbody;
	public CameraScript_ex01	my_cam;
	public RaycastHit2D	Hit;

	// Use this for initialization
	void Start () {
		Finish = 0;
		jumpTime = 0.3f;
		timer = 0;
		win = false;
		moveSpeed = 2;
		JumpSpeed = 2;
		touchGround = true;
		CurrentObj = Thomas;
		rayDistance = CurrentObj.GetComponent<BoxCollider2D> ().size;
		playerRigidbody = CurrentObj.GetComponent<Rigidbody2D> ();
		playerRigidbody.mass = 1;
		my_cam.target = CurrentObj;
	}

	void OnCollisionExit2D(Collision2D coll) {
		Hit = Physics2D.Raycast (new Vector2 (CurrentObj.transform.position.x, CurrentObj.transform.position.y - ((rayDistance.y/2) + 0.01f)), -Vector2.up, 0.1f);
		if (Hit.collider == null) {
			//Debug.Log ("TOUCH_GROUND");
			touchGround = false;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player" && !touchGround) {
			Hit = Physics2D.Raycast (new Vector2 (CurrentObj.transform.position.x + ((rayDistance.x / 2) - 0.1f), transform.position.y - ((rayDistance.y / 2) + 0.01f)), -Vector2.up, 0.1f);
			if (Hit.collider != null)
				touchGround = true;
			Hit = Physics2D.Raycast (new Vector2 (CurrentObj.transform.position.x - ((rayDistance.x / 2) - 0.1f), transform.position.y - ((rayDistance.y / 2) + 0.01f)), -Vector2.up, 0.1f);
			if (Hit.collider != null)
				touchGround = true;
		} if (coll.gameObject.tag == "ground") {
			Hit = Physics2D.Raycast (new Vector2 (CurrentObj.transform.position.x, CurrentObj.transform.position.y - ((rayDistance.y / 2) + 0.01f)), -Vector2.up, 0.1f);
			if (Hit.collider != null) {
				//Debug.Log ("TOUCH_GROUND");
				touchGround = true;
			}
		}
	}

	void	ft_change_player(float v, float h){
		playerRigidbody = CurrentObj.GetComponent<Rigidbody2D> ();
		rayDistance = CurrentObj.GetComponent<BoxCollider2D> ().size;
		playerRigidbody.mass = 1;
		moveSpeed = v;
		JumpSpeed = h;
		touchGround = true;
		my_cam.target = CurrentObj;
	}

	void ft_input_player(){
		if (Input.GetKey (KeyCode.Alpha1)) {
			playerRigidbody.mass = 1000;
			touchGround = true;
			CurrentObj = Thomas;
			ft_change_player(0.7f, 2f);
		}
		if (Input.GetKey (KeyCode.Alpha2)) {
			playerRigidbody.mass = 1000;
			touchGround = true;
			CurrentObj = Claire;
			ft_change_player(0.4f, 1.5f);
		}
		if (Input.GetKey (KeyCode.Alpha3)) {
			playerRigidbody.mass = 1000;
			touchGround = true;
			CurrentObj = John;
			ft_change_player(1f, 3f);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		//Debug.Log (coll.name);
		if (coll.name == "Thomas_Red_exit" && CurrentObj.name == "Thomas_Red")
			Finish = 1;
		if (coll.name == "Claire_Blue_exit" && CurrentObj.name == "Claire_Blue")
			Finish = 1;
		if (coll.name == "John_Yellow_exit" && CurrentObj.name == "John_Yellow")
			Finish = 1;
	}

	void OnTriggerExit2D(Collider2D coll) {
		//Debug.Log (coll.name);
		if (coll.name == "Thomas_Red_exit" && CurrentObj.name == "Thomas_Red")
			Finish -= 1;
		if (coll.name == "Claire_Blue_exit" && CurrentObj.name == "Claire_Blue")
			Finish -= 1;
		if (coll.name == "John_Yellow_exit" && CurrentObj.name == "John_Yellow")
			Finish -= 1;
	}

	void ft_input(){
		if (Input.GetKey (KeyCode.Backspace) || Input.GetKey (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevel);
		}
		if (Input.GetKey (KeyCode.LeftArrow))
			playerRigidbody.velocity = new Vector2(-1 * moveSpeed, playerRigidbody.velocity.y);
		if (Input.GetKey (KeyCode.RightArrow))
			playerRigidbody.velocity = new Vector2 (1 * moveSpeed, playerRigidbody.velocity.y);
		if (Input.GetKey (KeyCode.Space) && touchGround == true) {
			touchGround = false;
			timer = 0.0f;
		}
	}

	void ft_finish(){
		if (Application.loadedLevel == 0)
			Application.LoadLevel (1);
		if (Application.loadedLevel == 1)
			Application.LoadLevel (2);
		if (Application.loadedLevel == 2)
			Application.LoadLevel (3);
		if (Application.loadedLevel == 3)
			Application.LoadLevel (0);
		Debug.Log ("WIN");
		CurrentObj.GetComponent<playerScript_ex01> ().win = true;
		Thomas.GetComponent<playerScript_ex01> ().win = true;
		Claire.GetComponent<playerScript_ex01> ().win = true;
		John.GetComponent<playerScript_ex01> ().win = true;
	}

	// Update is called once per frame
	void Update () {
	//	Debug.DrawRay(new Vector2 (CurrentObj.transform.position.x, CurrentObj.transform.position.y - ((rayDistance.y/2) + 0.01f)), -Vector2.up);
		ft_input ();
		ft_input_player ();
		if ((Thomas.GetComponent<playerScript_ex01> ().Finish +
		     Claire.GetComponent<playerScript_ex01> ().Finish +
		     John.GetComponent<playerScript_ex01> ().Finish ) == 3 &&
		     CurrentObj.GetComponent<playerScript_ex01> ().win == false)
			ft_finish ();
		if (touchGround == false && timer < jumpTime)
			playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 1f * JumpSpeed);
		timer += Time.deltaTime;
	}
}
