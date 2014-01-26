using UnityEngine;
using System.Collections;

public class FireController : WithMouseActions
{
		public Sprite fireFull;
		public Sprite fire75;
		public Sprite fire25;
		public Sprite fireEmptyKey;
		public Sprite fireEmpty;
		int fills = 3;
		bool hasKey = true;
		BarrelController barrel;
		bool gettingColder = true;

		void Start ()
		{
				barrel = GameObject.Find ("barrel").GetComponent<BarrelController> ();
		}

		public override void PerformOnClickAction ()
		{
				//roomManager.AddInfoText ("More!");
				if (gettingColder && fills > 0) {
						FireDown ();	
				} else if (!gettingColder && fills < 3) {
						FireUp();
				}

		/*
				if (fills == 0 && hasKey) {
						GameObject.Find ("key").GetComponent<InventoryItem> ().InsertIntoInventory ();
						hasKey = false;
				}

				if (fills == 1) {
						roomManager.AddInfoText ("Fill the fire - I need more!");		
				}
				if (fills >= 0) {
						--fills;
				}
				UpdateSprite (); */
		}

		void UpdateSprite ()
		{
				if (fills >= 3) {
						GetComponent<SpriteRenderer> ().sprite = fireFull;
				} else if (fills == 2) {
						GetComponent<SpriteRenderer> ().sprite = fire75;
				} else if (fills == 1) {
						GetComponent<SpriteRenderer> ().sprite = fire25;
				} else if (fills == 0 && hasKey) {
						GetComponent<SpriteRenderer> ().sprite = fireEmptyKey;
				} else {
						GetComponent<SpriteRenderer> ().sprite = fireEmpty;
				}
		}

		public void FireUp ()
		{
				if (fills > 2) {
					gettingColder=true;
					if(!barrel.keyTaken)
						barrel.melt();
					return;
				}

				++fills;
				UpdateSprite ();
	
		}

		public void FireDown ()
		{
				if (fills == 0) {
					gettingColder=false;
					if(!barrel.keyTaken)
						barrel.burst();
					return;
				}
			
				--fills;
				UpdateSprite ();
			
		}
}
