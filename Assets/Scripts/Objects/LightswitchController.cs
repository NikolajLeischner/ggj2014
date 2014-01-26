using UnityEngine;
using System.Collections;

public class LightswitchController : WithMouseActions
{

		public Sprite switchOn;
		public Sprite switchOff;
		public Sprite roomDark;
		public Sprite roomLight;
		public Sprite roomDarkKey;
		public Sprite roomLightCracked;
		int remainingSwitches = 2;
		bool dark = false;

		public bool KeyWasRevealed ()
		{
				return remainingSwitches < 1;
		}

		void TurnOffSwitchAndSetRoomSprite (Sprite sprite)
		{
				dark = true;
				GetComponent<SpriteRenderer> ().sprite = switchOff;
		GameObject.Find ("room_background").GetComponent<SpriteRenderer> ().sprite = sprite;
		}

		public override void PerformOnClickAction ()
		{
				if (remainingSwitches == 2 && !dark) {
						TurnOffSwitchAndSetRoomSprite (roomDark);
						roomManager.AddInfoText ("I am afraid of the dark!");
						StartCoroutine (WaitAndTurnOnLightAgain (roomLight));

				} else if (remainingSwitches == 1 && !dark) {
						TurnOffSwitchAndSetRoomSprite (roomDarkKey);
						roomManager.AddInfoText ("...");
						StartCoroutine (WaitAndTurnOnLightAgain (roomLightCracked));
				}
		}

		IEnumerator WaitAndTurnOnLightAgain (Sprite sprite)
		{
				yield return new WaitForSeconds (2);
				GetComponent<SpriteRenderer> ().sprite = switchOn;
		GameObject.Find ("room_background").GetComponent<SpriteRenderer> ().sprite = sprite;
				--remainingSwitches;
		dark = false;
		}
}
