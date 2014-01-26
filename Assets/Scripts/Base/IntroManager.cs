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

		messages [0] = "Perspectives... ";
		messages [1] = "Everyone sees in their own way";
		messages [2] = "One person's hell is another's utopia";
		messages [3] = "Everything is what it is";
		messages [4] = "But how we see them depends on ourself";
		messages [5] = "This is the story of Nemo and his mind";

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
