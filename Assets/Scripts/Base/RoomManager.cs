using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour
{

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

		void Start ()
		{
				GameManager manager = GameManager.instance ();
				manager.currentRoom = name;
				header.text = name;
				timer.text = "";

				startTime = Time.time;
				endTime = startTime + timeLimit;
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
				UpdateMouse ();
	
		}
}
