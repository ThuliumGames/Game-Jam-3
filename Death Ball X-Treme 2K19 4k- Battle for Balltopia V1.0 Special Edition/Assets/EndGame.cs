using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

	void Update () {
		
		transform.Rotate(0, 0, 500*Time.deltaTime);
		if (Vector3.Distance(new Vector3 (0, 0, 0), GameObject.Find("Player1").transform.position) > 200 || Vector3.Distance(new Vector3 (0, 0, 0), GameObject.Find("Player2").transform.position) > 200) {
			Application.LoadLevel("CharC");
		}
		if (Vector3.Distance(transform.position, GameObject.Find("Player1").transform.position) < 2) {
			Application.LoadLevel("CharC");
		}
		if (Vector3.Distance(transform.position, GameObject.Find("Player2").transform.position) < 2) {
			Application.LoadLevel("CharC");
		}
	}
}
