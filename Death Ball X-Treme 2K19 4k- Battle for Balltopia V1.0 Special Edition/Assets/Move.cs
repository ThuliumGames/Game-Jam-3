using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {
	
	GameObject[] planets;
	
	public string MoveAxisName;
	public string JumpButtonName;
	public string AttackButtonName;
	
	public int Damage = 0;
	public Text Dt;
	public string T;
	
	int Invert;
	void Start () {
		Invert = 100;
		planets = GameObject.FindGameObjectsWithTag("Planet");
	}
	
	void Update () {
		
		Dt.text = T + Damage;
		
		//Physics Calc
		float Dist = 100000;
		Vector3 Pos = transform.position;
		foreach (GameObject P in planets) {
			if (Vector3.Distance (transform.position, P.transform.position) <= Dist) {
				print (P.name);
				Dist = Vector3.Distance (transform.position, P.transform.position);
				Pos = P.transform.position;
			}
		}
		transform.eulerAngles = new Vector3 (0, 0, Mathf.Atan2(transform.position.x - Pos.x, Pos.y - transform.position.y)*Mathf.Rad2Deg);
		transform.Rotate(0, 0, 180);
		GetComponent<Rigidbody2D>().AddRelativeForce (new Vector2 (0, -250*Time.deltaTime));
		
		//Movement
		
		if (Input.GetAxisRaw(MoveAxisName) == 0) {
			if (Invert == 100 && transform.eulerAngles.z > 100 && transform.eulerAngles.z < 260) {
				//Invert = -100;
			}
			if (Invert == -100 && transform.eulerAngles.z < 80 || transform.eulerAngles.z > 280) {
				//Invert = 100;
			}
		} else {
			transform.localScale = new Vector3 (Input.GetAxisRaw(MoveAxisName)/10, 0.1f, 1);
		}
		GetComponent<Rigidbody2D>().AddRelativeForce (new Vector2 (Input.GetAxis(MoveAxisName)*Invert*Time.deltaTime, 0));
		if (Input.GetButton(JumpButtonName)) {
			GetComponent<Rigidbody2D>().AddRelativeForce (new Vector2 (0, 500*Time.deltaTime));
		}
		if (Input.GetButtonDown(AttackButtonName)) {
			BroadcastMessage("Attack");
		}
	}
}
