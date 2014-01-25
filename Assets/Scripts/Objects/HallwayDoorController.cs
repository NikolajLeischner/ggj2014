using UnityEngine;
using System.Collections;

public class HallwayDoorController : WithMouseActions
{
		int remainingTries = 3;

		public override void PerformOnClickAction ()
	{
		print (remainingTries);
				GuardController guard = GameObject.Find ("guard").GetComponent<GuardController> ();
				if (guard.IsDistracted ()) {
						roomManager.MoveToNextRoom ();		
				} else {
						if (remainingTries > 0) {
								roomManager.AddInfoText ("Distract the guard!");
								--remainingTries;
						} else {
								roomManager.MoveToPaddedCell ();
						}
				}
		}
}
