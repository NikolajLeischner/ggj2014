using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour
{

		// Header
		public string roomName;
		public GUIText header;

		// Character portrait
		public Texture2D characterCat;
		public Texture2D characterNapoleon;
		public Texture2D characterGirl;
		public GUITexture characterPortrait;
		public string nextRoom;

		// Timer
		public float timeLimit;
		public GUIText timer;
		float startTime;
		float endTime;

		// Info text
		public GUIText info;
		float textEndTime = 0;
		public float textFadeoutSeconds = 10;

		public void SetCharacter (Characters character)
		{
				if (character == Characters.Cat) {
						characterPortrait.texture = characterCat;
				} else if (character == Characters.Girl) {
						characterPortrait.texture = characterGirl;
				} else if (character == Characters.Napoleon) {
						characterPortrait.texture = characterNapoleon;
				}
		}

		public void AddItemToInventory (GameObject gameObject)
		{

		}

		bool HasTimeLimit ()
		{
				return timeLimit > 0.0f;
		}

		void MoveToPaddedCell ()
		{
				Application.LoadLevel (Rooms.PaddedCell);
		}

		public void MoveToNextRoom ()
		{
				Application.LoadLevel (nextRoom);
		}

		void SetInfoAlpha (float alpha)
		{
				info.material.color = new Color (1.0f, 1.0f, 1.0f, alpha);
		}

		public void AddInfoText (string text)
		{
				textEndTime = Time.time + textFadeoutSeconds;
				info.text = text;
				SetInfoAlpha (1.0f);
		}

		void Start ()
		{
				GameManager manager = GameManager.instance ();
				manager.currentRoom = roomName;
				header.text = roomName;
				timer.text = "";

				startTime = Time.time;
				endTime = startTime + timeLimit;

				info.text = "...";
				SetInfoAlpha (1.0f);

				AddInfoText ("fading out..");

		SetCharacter (Characters.Girl);
		}

		void UpdateInfo ()
		{
				float remainingTime = textEndTime - Time.time;
				if (remainingTime > 0.0f) {
						float percentage = remainingTime / textFadeoutSeconds;
						SetInfoAlpha (percentage);
				} else {
						info.text = "";		
				}
		}

		void UpdateTimer ()
		{
				if (HasTimeLimit ()) {
						float remainingTime = endTime - Time.time;

						timer.text = "" + Mathf.RoundToInt (remainingTime);

						if (remainingTime <= 0.0f) {
								MoveToPaddedCell ();
						}
				}
		}

		void UpdateMouse ()
		{
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				if (hit.collider != null) { 
						WithMouseActions gameObject = hit.collider.gameObject.GetComponent<WithMouseActions> ();
			
						if (gameObject != null) {
								if (Input.GetMouseButton (0)) {
										gameObject.PerformOnClickAction ();
								} else {
										gameObject.PerformOnHoverAction ();
								}
						} 
				}
		}

		void Update ()
		{
				UpdateTimer ();
				UpdateInfo ();
				UpdateMouse ();
	
		}
}
