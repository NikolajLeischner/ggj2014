using UnityEngine;
using System.Collections;

public class TimerManager : MonoBehaviour
{
	public float timeLimit;
	public GUIText timerText;
	public RoomManager room;
	public SpriteRenderer timerBar;			// Reference to the sprite renderer of the health bar.

	private Vector3 timerScale;				// The local scale of the health bar initially (with full health).


	float startTime;
	float endTime;
	int lastRemainingSeconds;
	int lastSwitch;
	
	bool HasTimeLimit ()
	{
		return timeLimit > 0.0f;
	}
	
	void Start ()
	{	
		if (HasTimeLimit()) {
			//timerBar = GameObject.Find("TimerBar").GetComponent<SpriteRenderer>();
			
			// Getting the intial scale of the healthbar (whilst the player has full health).
			timerScale = timerBar.transform.localScale;
			
			startTime = Time.time;
			endTime = startTime + timeLimit;
		}
	}
	
	public void UpdateTimer ()
	{
		if (HasTimeLimit ()) {
			float remainingTime = endTime - Time.time;
			// temp for presentation
			if(Mathf.RoundToInt(remainingTime % 5) == 0 && lastSwitch != Mathf.RoundToInt(remainingTime)) {
				UIManager ui = GameObject.Find("UIManager").GetComponent<UIManager>();
				ui.character.RandomCharacter(ui.character.playerChar.characterIndex);
				lastSwitch = Mathf.RoundToInt(remainingTime);
				//print (remainingTime + " " + ui.character.playerChar.characterIndex);
			}
			//print(remainingTime % 5);

			timerText.text = "" + Mathf.RoundToInt (remainingTime);
			
			// Set the scale of the health bar to be proportional to the player's health.
			// change 3 to the starting scale of the final sprite, should be 1
			timerBar.transform.localScale = new Vector3(1, remainingTime / timeLimit * 1, 1);
			
			if (remainingTime <= 0.0f) {
				//room = GameObject.Find ("RoomManager").GetComponent<RoomManager> ();
				room.MoveToPaddedCell();
			}

			lastRemainingSeconds = Mathf.RoundToInt (remainingTime);
		}
	}
}
