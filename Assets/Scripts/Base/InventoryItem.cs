using UnityEngine;
using System.Collections;

public class InventoryItem : WithMouseActions
{
		public Sprite inRoom;
	public Sprite inRoomHover;
	public Sprite inInventory;
	public Sprite inInventoryHover;
	public Sprite inInventoryActive;
		bool isInInventory;
	bool isActive = false;

	public override void PerformOnClickAction() {
		if (!isInInventory) {
						InsertIntoInventory ();
				} else {
			roomManager.SetItemActive(this);
				}
	}

	public void SetActive(bool active) {
		isActive = active;
	}

	public bool IsActive() {
		return isActive;
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

		public override void PerformOnHoverAction ()
		{
				base.PerformOnHoverAction ();

				SetSpriteToHover ();
		}

		void SetSpriteToNormal ()
		{
				if (isInInventory) {
			if (IsActive()) {
				GetComponent<SpriteRenderer> ().sprite = inInventoryActive;
			} else {
				GetComponent<SpriteRenderer> ().sprite = inInventory; }
				} else {
			GetComponent<SpriteRenderer> ().sprite = inRoom;
				}
		}

		void SetSpriteToHover ()
		{
		if (isInInventory) {
			if (IsActive()) {
				GetComponent<SpriteRenderer> ().sprite = inInventoryActive;}
			else {
				GetComponent<SpriteRenderer> ().sprite = inInventoryHover;}
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
