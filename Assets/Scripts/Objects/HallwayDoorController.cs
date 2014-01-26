using UnityEngine;
using System.Collections;

public class HallwayDoorController : WithMouseActions
{
		public int tries = 3;

		public override void PerformOnClickAction ()
		{
				print ("remaining tries: " + tries);
				GuardController guard = GameObject.Find ("guard").GetComponent<GuardController> ();
				if (guard.IsDistracted ()) {
			audio.Play();
						roomManager.MoveToNextRoom ();		
				} else {
						if (tries > 0) {
								roomManager.AddInfoText ("Distract the guard!");
								--tries;
						} else {
								roomManager.ReloadCurrentRoom ();
						}
				}
		}
}
