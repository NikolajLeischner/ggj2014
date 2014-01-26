using UnityEngine;
using System.Collections;

public class CrackController : WithMouseActions
{
		bool wasTriggered = false;

		public override void PerformOnClickAction ()
		{
				if (!wasTriggered) {

						LightswitchController lightswitch = GameObject.Find ("lightswitch").GetComponent<LightswitchController> ();

						if (lightswitch.KeyWasRevealed ()) {
								GameObject.Find ("key").transform.position = new Vector3 (2.9f, -2.73f, 0.0f);
								wasTriggered = true;
						}
				}
		}
}
