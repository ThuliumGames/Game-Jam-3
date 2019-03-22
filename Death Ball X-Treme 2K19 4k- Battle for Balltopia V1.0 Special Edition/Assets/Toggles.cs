using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggles : MonoBehaviour {
	
	public int Player;
	
	public Sprite[] eyes;
	public Sprite[] hats;
	public Color[] color;
	int colors = 0;
	
	public Image[] SR;
	
	void Update () {
		if (GetComponent<Image>() == SR[0]) {
			SR[0].color = Customize.theColor1;
			SR[1].color = Customize.theColor2;
			SR[2].sprite = eyes[Customize.Eye1];
			SR[3].sprite = eyes[Customize.Eye2];
			SR[4].sprite = hats[Customize.Hat1];
			SR[5].sprite = hats[Customize.Hat2];
		}
	}
	
	void PG () {
		Application.LoadLevel("SampleScene");
	}
	
	void Te () {
		if (Player == 0) {
			Customize.Eye1++;
			if (Customize.Eye1 == 5) {
				Customize.Eye1 = 0;
			}
		} else {
			Customize.Eye2++;
			if (Customize.Eye2 == 5) {
				Customize.Eye2 = 0;
			}
		}
	}
	void Th () {
		if (Player == 0) {
			Customize.Hat1++;
			if (Customize.Hat1 == 4) {
				Customize.Hat1 = 0;
			}
		} else {
			Customize.Hat2++;
			if (Customize.Hat2 == 4) {
				Customize.Hat2 = 0;
			}
		}
	}
	void Tc () {
		colors++;
		if (colors == 8) {
			colors = 0;
		}
		if (Player == 0) {
			Customize.theColor1 = color[colors];
		} else {
			Customize.theColor2 = color[colors];
		}
	}
}
