using UnityEngine;
using System.Collections;

public class TimerManager : MonoBehaviour
{
	public float timeLimit;
	public GUIText timerText;
	public RoomManager room;
	public SpriteRenderer timerBar;			// Reference to the sprite renderer of the health bar.


	float startTime;
	float endTime;
	
	bool HasTimeLimit ()
	{
		return timeLimit > 0.0f;
	}
	
	void Start ()
	{	
		if (HasTimeLimit()) {
			startTime = Time.time;
			endTime = startTime + timeLimit;
		}
	}
	
	public void UpdateTimer ()
	{
		if (HasTimeLimit ()) {
			float remainingTime = endTime - Time.time;

			timerText.text = "" + Mathf.RoundToInt (remainingTime);
			
			// Set the scale of the health bar to be proportional to the player's health.
			// change 3 to the starting scale of the final sprite, should be 1
			timerBar.transform.localScale = new Vector3(1, remainingTime / timeLimit * 1, 1);
			
			if (remainingTime <= 0.0f) {
				//room = GameObject.Find ("RoomManager").GetComponent<RoomManager> ();
				room.MoveToPaddedCell();
			}
		}
	}
}
