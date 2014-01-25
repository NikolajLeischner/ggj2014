using UnityEngine;
using System.Collections;

public class DoorController : WithMouseActions {

	public override void PerformOnClickAction() {
		InventoryItem key = GameObject.Find ("key").GetComponent<InventoryItem> ();
		if (key.IsActive ()) {
						roomManager.MoveToNextRoom ();		
				} else {
			roomManager.AddInfoText ("It is not *that* easy!");
				}
	}
}
