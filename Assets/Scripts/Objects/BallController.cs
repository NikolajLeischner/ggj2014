using UnityEngine;
using System.Collections;

public class BallController : WithMouseActions
{


		public Vector3 targetPosition;
		bool wasTriggered = false;

		public override void PerformOnClickAction ()
		{
				if (!wasTriggered) {
						wasTriggered = true;
						StartCoroutine (MoveToTarget (targetPosition));
				}

		}

		IEnumerator MoveToTarget (Vector3 target)
		{
		audio.Play ();
				while (Vector3.Distance(transform.position, target) > 0.05f) {
						transform.position = Vector3.Lerp (transform.position, target, 1f * Time.deltaTime);
			
						yield return null;
				}
		
				print ("Reached the target.");
				GuardController guard = GameObject.Find ("guard").GetComponent<GuardController> ();
				guard.Distract ();
		}

}
