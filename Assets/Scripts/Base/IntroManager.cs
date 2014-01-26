using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour
{
	public GUIText timerText;
	public RoomManager room;
	int lastMessage = -1;
	string[] messages = new string[3];

	float startTime;

	void Start ()
	{	
		startTime = Time.time;

		messages [0] = "test";
		messages [1] = "aksdnkalsjdlka";
		messages [2] = "aksdnkalsjdlka";

	}
	
	void Update ()
	{
		float currentTime = Time.time - startTime;
		int nextMessage = Mathf.RoundToInt (currentTime / 7);

		if (nextMessage != lastMessage) {
			if (nextMessage < messages.Length - 1) {
				room.AddInfoText (messages[nextMessage]);
			}
			else {
				GameManager.instance().currentRoom = Rooms.Bedroom;
				room.MoveToNextRoom();
			}
				}
	}
}
