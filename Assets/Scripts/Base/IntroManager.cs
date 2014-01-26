using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour
{
	//public float timeLimit;
	public GUIText timerText;
	public RoomManager room;
	//public SpriteRenderer timerBar;			// Reference to the sprite renderer of the health bar.
	int lastMessage = -1;
	string[] messages = new string[10];

	float startTime;

	void Start ()
	{	
		//UIManager ui = GameObject.Find ("ui").GetComponent<UIManager> ();
		//ui.timer = GetComponent<IntroManager> ();
		startTime = Time.time;

		messages [0] = "test";
		messages [1] = "aksdnkalsjdlka";

	}
	
	void Update ()
	{
		float currentTime = Time.time - startTime;
		int nextMessage = Mathf.RoundToInt (currentTime / 7);

		if(nextMessage!=lastMessage)
			room.AddInfoText (messages[nextMessage]);
	}
}
