using UnityEngine;
using System.Collections;

public class DoorController : WithMouseActions
{

		public Sprite BedroomOpen;
		bool wasTriggered = false;

		public override void PerformOnClickAction ()
		{
				InventoryItem key = GameObject.Find ("key").GetComponent<InventoryItem> ();
				if (!wasTriggered && key.IsActive ()) {
						wasTriggered = true;
						StartCoroutine (OpenDoorAndMove ());	
				} else {
						roomManager.AddInfoText ("It is not *that* easy!");
				}
		}

		IEnumerator OpenDoorAndMove ()
		{
				GameObject.Find ("bedroom").GetComponent<SpriteRenderer> ().sprite = BedroomOpen;
				yield return new WaitForSeconds (2);
				roomManager.MoveToNextRoom ();	
		}
}
