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
								GameObject.Find ("key").transform.position = new Vector3 (0.08f, -2.19f, 0.0f);
								wasTriggered = true;
						}
				}
		}
}
