using UnityEngine;
using System.Collections;

public class OutroManager : MonoBehaviour
{
	public GUIText timerText;
	public RoomManager room;
	int lastMessage = -1;
	string[] messages = new string[10];
	
	float startTime;
	
	void Start ()
	{	
		startTime = Time.time;
		
		messages [0] = "Congratulations";
		messages [1] = "You have set them free";
		messages [2] = "Nemo's mind is now empty";
		messages [3] = "";
	}
	
	void Update ()
	{
		float currentTime = Time.time - startTime;
		int nextMessage = Mathf.RoundToInt (currentTime / 7);
		
		if(nextMessage!=lastMessage)
			room.AddInfoText (messages[nextMessage]);

		if (lastMessage == 5)
						Application.Quit ();
	}
}
