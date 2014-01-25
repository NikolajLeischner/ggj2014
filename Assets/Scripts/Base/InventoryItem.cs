using UnityEngine;
using System.Collections;

public class InventoryItem : WithMouseActions
{

		RoomManager roomManager;
		public Sprite inRoom;
	public Sprite inRoomHover;
	public Sprite inInventory;
	public Sprite inInventoryHover;
		bool isInInventory;

	public override void PerformOnClickAction() {
		InsertIntoInventory ();
	}

		public void InsertIntoInventory ()
		{
				if (!isInInventory) {
						roomManager.AddItemToInventory (this);
				}
				isInInventory = true;

		}

		public void RemoveFromInventory ()
		{
				if (isInInventory) {
						roomManager.RemoveItemFromInventory (this);
				}
				isInInventory = false;

		}

		void Start ()
		{
				roomManager = GameObject.Find ("RoomManager").GetComponent<RoomManager> ();
		}

		public override void PerformOnHoverAction ()
		{
				base.PerformOnHoverAction ();

				SetSpriteToHover ();
		}

		void SetSpriteToNormal ()
		{
				if (isInInventory) {
			GetComponent<SpriteRenderer> ().sprite = inInventory;
				} else {
			GetComponent<SpriteRenderer> ().sprite = inRoom;
				}
		}

		void SetSpriteToHover ()
		{
				if (isInInventory) {
			GetComponent<SpriteRenderer> ().sprite = inInventoryHover;
				} else {
			GetComponent<SpriteRenderer> ().sprite = inRoomHover;
				}
		}

		void Update ()
		{
				if (!MouseHovers ()) {
						SetSpriteToHover ();
				} else {
						SetSpriteToNormal ();		
				}
		}

}
