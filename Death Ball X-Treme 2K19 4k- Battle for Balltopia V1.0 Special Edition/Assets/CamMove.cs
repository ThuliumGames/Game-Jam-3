using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour {
	
	public Transform[] F;
	
	void Update () {
		transform.position = ((F[0].position+F[1].position)/2) + new Vector3 (0, 0, -10);
		GetComponent<Camera>().orthographicSize = Mathf.Clamp (Vector3.Distance (F[0].position, F[1].position), 5, 200);
	}
}
