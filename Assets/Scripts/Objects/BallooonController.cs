using UnityEngine;
using System.Collections;

public class DoorController : WithMouseActions {
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
					// todo guard looks to side
				} else {
			roomManager.AddInfoText ("It is not *that* easy!");
				}
	}
}
