using UnityEngine;
using System.Collections;

public class playerScript_ex00 : MonoBehaviour {
	
	public GameObject	Thomas;
	public GameObject	Clair;
	public GameObject	John;
	public GameObject	CurrentObj;
	public float		moveSpeed;
	public float 		jumpTime;
	public float 		timer;
	public bool 		touchGround;
	public Rigidbody2D 	playerRigidbody;
	public CameraScript	my_cam;
	public RaycastHit2D	Hit;

	// Use this for initialization
	void Start () {
		jumpTime = 0.3f;
		timer = 0;
		touchGround = true;
		CurrentObj = Thomas;
		playerRigidbody = CurrentObj.GetComponent<Rigidbody2D> ();
		playerRigidbody.mass = 1;
		my_cam.target = CurrentObj;
	}

//	void OnCollisionExit2D(Collision2D coll) {
//		if (coll.gameObject.tag == "Wall") {
//			Debug.Log("EXIT");
//		}
//	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "ground")
			touchGround = true;
			
			//		Debug.Log (coll.gameObject.tag);
		if (coll.gameObject.tag == "Player") {
		
//			//Debug.DrawRay(CurrentObj.transform.position, new Vector3(1,0,0) * 10 ,Color.green);
			Hit = Physics2D.Raycast (CurrentObj.transform.position, -Vector2.up);
			if (Hit.collider != null && Hit.collider.tag == "Player"){
				Debug.Log (Hit.collider.tag);
					touchGround = true;
			}
		}
	}

	void	ft_change_player(float v){
		playerRigidbody = CurrentObj.GetComponent<Rigidbody2D> ();
		playerRigidbody.mass = 1;
		moveSpeed = v;
		my_cam.target = CurrentObj;
	}

	void ft_input_player(){
		if (Input.GetKey (KeyCode.Alpha1)) {
			playerRigidbody.mass = 1000;
			touchGround = true;
			CurrentObj = Thomas;
			ft_change_player(3f);
		}
		if (Input.GetKey (KeyCode.Alpha2)) {
			playerRigidbody.mass = 1000;
			touchGround = true;
			CurrentObj = Clair;
			ft_change_player(0.8f);
		}
		if (Input.GetKey (KeyCode.Alpha3)) {
			playerRigidbody.mass = 1000;
			touchGround = true;
			CurrentObj = John;
			ft_change_player(1.6f);
		}
	}

	void ft_input(){
		if (Input.GetKey (KeyCode.Backspace) || Input.GetKey (KeyCode.R))
			Application.LoadLevel (0);
		if (Input.GetKey (KeyCode.LeftArrow))
			playerRigidbody.velocity = new Vector2(-1 * moveSpeed, playerRigidbody.velocity.y);
			//CurrentObj.transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);
		if (Input.GetKey (KeyCode.RightArrow))
			playerRigidbody.velocity = new Vector2 (1 * moveSpeed, playerRigidbody.velocity.y);
			//CurrentObj.transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);
		if (Input.GetKey (KeyCode.Space) && touchGround == true) {
			touchGround = false;
			timer = 0.0f;
		}
	}

	// Update is called once per frame
	void Update () {
		Debug.DrawRay(CurrentObj.transform.position, -Vector2.up * 10 ,Color.green);
		ft_input ();
		ft_input_player ();
		if (touchGround == false && timer < jumpTime)
			playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 1f * moveSpeed);
		timer += Time.deltaTime;
	}
}
