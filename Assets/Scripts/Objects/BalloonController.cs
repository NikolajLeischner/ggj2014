﻿using UnityEngine;
using System.Collections;

public class BalloonController : WithMouseActions {
	public Sprite whole;
	public Sprite broken;
	public bool popped=false;

	void Start() {
		GetComponent<SpriteRenderer> ().sprite = whole;
	}

	public override void PerformOnClickAction() {
		InventoryItem key = GameObject.Find ("pin").GetComponent<InventoryItem> ();
		if (key.IsActive ()) {
					GetComponent<SpriteRenderer> ().sprite = broken;	
					popped = true;
			GuardController guard = GameObject.Find("guard").GetComponent<GuardController> ();
			guard.Distract();
				} else {
			//roomManager.AddInfoText ("It is not *that* easy!");
				}
	}
}