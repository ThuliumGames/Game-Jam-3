using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour {
	
	float Cooldown;
	
	public Transform p;
	public GameObject Explode;
	
	void Update () {
		Cooldown -= Time.deltaTime;
		Cooldown = Mathf.Clamp (Cooldown, 0, 10);
		if (Cooldown == 0) {
			transform.localEulerAngles = new Vector3 (0, 0, 0);
		} else {
			transform.localEulerAngles = new Vector3 (0, 0, -90);
		}
	}
	
	public void Attack () {
		if (Cooldown < 0.2f && Cooldown != 0) {
			StartCoroutine("Do", 0.3f-Cooldown);
			Cooldown = 0;
		} else if (Cooldown == 0) {
			StartCoroutine("Do", 0.05f);
		} else {
			Cooldown = 0.5f;
		}
	}
	
	IEnumerator Do (float Power) {
		Cooldown = 0.5f;
		if (Vector3.Distance (GameObject.Find("Player1").transform.position, GameObject.Find("Player2").transform.position) < 2.5f) {
			
			if (GetComponentInParent<Move>().name == "Player1") {
				Instantiate (Explode, GameObject.Find("Player2").transform.position-Vector3.forward, Quaternion.Euler (0, 0, 0));
				
				GameObject.Find("Player2").GetComponent<Move>().Damage += (((int)Power*10)+10);
				GameObject.Find("Player2").GetComponent<Rigidbody2D>().AddForce ((GameObject.Find("Player2").transform.position-GameObject.Find("Player1").transform.position).normalized*500*GameObject.Find("Player2").GetComponent<Move>().Damage*Time.deltaTime);
			} else {
				Instantiate (Explode, GameObject.Find("Player1").transform.position-Vector3.forward, Quaternion.Euler (0, 0, 0));
				
				GameObject.Find("Player1").GetComponent<Move>().Damage += (((int)Power*10)+10);
				GameObject.Find("Player1").GetComponent<Rigidbody2D>().AddForce ((GameObject.Find("Player1").transform.position-GameObject.Find("Player2").transform.position).normalized*500*GameObject.Find("Player1").GetComponent<Move>().Damage*Time.deltaTime);
			}
		}
		yield return new WaitForSeconds (0);
	}
}
