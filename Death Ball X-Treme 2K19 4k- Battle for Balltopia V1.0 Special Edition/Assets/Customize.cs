using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customize : MonoBehaviour {
	
	public Sprite[] eyes;
	public Sprite[] hats;
	public GameObject[] weapon;
	
	public SpriteRenderer EyeGO;
	public SpriteRenderer HatGO;
	
	public static Color theColor1 = Color.white;
	public static Color theColor2 = Color.white;
	public static int Eye1;
	public static int Eye2;
	public static int Weap1;
	public static int Weap2;
	public static int Hat1;
	public static int Hat2;
	
	void Start () {
		if (name == "Player1") {
			GetComponent<SpriteRenderer>().color = theColor1;
			EyeGO.sprite = eyes[Eye1];
			HatGO.sprite = hats[Hat1];
			GameObject Go = Instantiate (weapon[Weap1], transform.position, Quaternion.identity);
			Go.transform.SetParent(transform);
		} else {
			GetComponent<SpriteRenderer>().color = theColor2;
			EyeGO.sprite = eyes[Eye2];
			HatGO.sprite = hats[Hat2];
			GameObject Go = Instantiate (weapon[Weap2], transform.position, Quaternion.identity);
			Go.transform.SetParent(transform);
		}
	}
}
