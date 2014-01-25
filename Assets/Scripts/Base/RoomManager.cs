using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour
{
	public GUIText header;
	public GUIText timer;
	public string roomName;
	public GUITexture characterPortrait;
	public float timeLimit;
	public string nextRoom;
	public UIManager ui;
	private SpriteRenderer timerBar;			// Reference to the sprite renderer of the health bar.
	private Vector3 timerScale;				// The local scale of the health bar initially (with full health).
	
	float startTime;
	float endTime;
	
	// Info text
	public GUIText info;
	float textEndTime = 0;
	public float textFadeoutSeconds = 10;

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
	
	bool HasTimeLimit ()
	{
		return timeLimit > 0.0f;
	}
	
	public void MoveToPaddedCell ()
	{
		Application.LoadLevel (Rooms.Bedroom);
	}
	
	public void MoveToNextRoom ()
	{
		int characterId = GameManager.instance ().NextRandomCharacterId ();
		Character character = Character.CharacterForId (characterId);
		string nextLevel = Rooms.SceneForCharacter (nextRoom, character);
		Application.LoadLevel (nextLevel);
	}

	void Start ()
	{
		GameManager manager = GameManager.instance ();
		int characterId = manager.CurrentCharacterId();
		//ui = GameObject.Find ("UIManager").GetComponent<UIManager> ();

		// TODO
		ui.character.ChangeCharacter (characterId);
		manager.currentRoom = roomName;
		header.text = roomName;
		timer.text = "";
		
		timerBar = GameObject.Find ("TimerBar").GetComponent<SpriteRenderer> ();
		
		// Getting the intial scale of the healthbar (whilst the player has full health).
		timerScale = timerBar.transform.localScale;
		
		startTime = Time.time;
		endTime = startTime + timeLimit;

		InitInventory ();
	}
	
	void UpdateMouse ()
	{
		RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
		if (hit.collider != null) { 
			WithMouseActions gameObject = hit.collider.gameObject.GetComponent<WithMouseActions> ();
			
			if (gameObject != null) {
				if (Input.GetMouseButtonDown (0)) {
					gameObject.PerformOnClickAction ();
				} else {
					gameObject.PerformOnHoverAction ();
				}
			} 
		}
	}
	
	void Update ()
	{
		ui.timer.UpdateTimer ();
		UpdateInfo ();
		UpdateWithMouseActions ();
		UpdateMouse ();
		
	}
	
	// Inventory
	public Inventory inventory;
	public Vector3 inventoryPosition1;
	public Vector3 inventoryPosition2;
	public Vector3 inventoryPosition3;
	
	void InitInventory ()
	{
		ArrayList freePositions = new ArrayList ();
		freePositions.Add (inventoryPosition1);
		freePositions.Add (inventoryPosition2);
		freePositions.Add (inventoryPosition3);
		inventory = new Inventory (freePositions);
	}
	
	public void SetItemActive (InventoryItem item)
	{
		inventory.SetItemActive (item);
	}
	
	public void AddItemToInventory (InventoryItem item)
	{
		inventory.AddItemToInventory (item);
	}
	
	public void RemoveItemFromInventory (InventoryItem item)
	{
		inventory.RemoveItemFromInventory (item);
	}
	
	// Bookkeeping for WithMouseActions objects.
	ArrayList withMouseActions = new ArrayList ();
	
	void UpdateWithMouseActions ()
	{
		foreach (WithMouseActions e in withMouseActions) {
			e.ResetHoverState ();		
		}
	}
	
	public void RegisterWithMouseActions (WithMouseActions toAdd)
	{
		withMouseActions.Add (toAdd);
	}
}
