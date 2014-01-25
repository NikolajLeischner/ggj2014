using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour
{

		public GUIText info;
		public GUIText header;
		public GUIText timer;
		public string roomName;
		public Texture2D characterCat;
		public Texture2D characterNapoleon;
		public Texture2D characterGirl;
		public GUITexture characterPortrait;
		public float timeLimit;
		public string nextRoom;
		float startTime;
		float endTime;
		float textEndTime = 0;
		public float textFadeoutSeconds = 10;

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
