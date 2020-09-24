﻿using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Treasure : Interactable {


	public UI UI;
	public int pageCount; 
	public Animator animator;

	bool isOpen = false;
	public Item[] items;
	public Text letter;
	

	void Start() {
		//animator = GetComponent<Animator> ();
	}

	public override void Interact ()
	{
		//base.Interact ();
		if (!isOpen) {
			UI.setTreasure(this);
			UI.SetPages(pageCount, letter.text);
			//animator.SetTrigger ("OpenLetter");
			StartCoroutine (CollectTreasure ());
		}
	}

	IEnumerator CollectTreasure() {

		isOpen = true;
		
		Debug.Log("ITS TREASURE");
			

		yield return new WaitForSeconds (1f);
		print ("Chest opened");
	/*	foreach (Item i in items) {
			Inventory.instance.Add (i);
		}*/
		yield return new WaitForSeconds (2f);

	}

	public void SetAnim(string parametr){
		animator.SetTrigger (parametr);
	}


}


