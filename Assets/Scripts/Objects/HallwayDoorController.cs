using UnityEngine;
using System.Collections;

public class HallwayDoorController : WithMouseActions {

	public override void PerformOnClickAction() {
		GuardController guard = GameObject.Find ("guard").GetComponent<GuardController> ();
		if (guard.isDistracted ()) {
						roomManager.MoveToNextRoom ();		
				} else {
			roomManager.AddInfoText ("It is not *that* easy!");
				}
	}
}
