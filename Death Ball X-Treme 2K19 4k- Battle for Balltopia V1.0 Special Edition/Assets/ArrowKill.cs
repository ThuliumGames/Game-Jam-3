using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKill : MonoBehaviour {
	
	void Start () {
		Invoke("Kill", 1.5f);
	}
	
	void Kill () {
		Destroy (this.gameObject);
	}
}
