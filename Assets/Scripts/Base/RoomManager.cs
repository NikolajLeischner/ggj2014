using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour
{

		public GUIText header;
		public GUIText timer;
		public string roomName;
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

	public void MoveToNextRoom() {
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

		void Update ()
		{
				UpdateTimer ();
	
		}
}
