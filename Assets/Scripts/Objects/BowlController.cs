using UnityEngine;
using System.Collections;

public class BowlController : WithMouseActions
{
		public Sprite bowlFull;
		public Sprite bowl75;
		public Sprite bowl25;
		public Sprite bowlEmptyKey;
		public Sprite bowlEmpty;
		int fills = 3;
		bool hasKey = true;

		public override void PerformOnClickAction ()
		{
				roomManager.AddInfoText ("More!");
		
				if (fills == 0 && hasKey) {
						GameObject.Find ("key").GetComponent<InventoryItem> ().InsertIntoInventory ();
						hasKey = false;
				}

				if (fills == 1) {
						roomManager.AddInfoText ("Fill the bowl - I need more!");		
				}
				UpdateSprite ();
				if (fills > 0) {
						--fills;
				}
		}

		void UpdateSprite ()
		{
				if (fills >= 3) {
						GetComponent<SpriteRenderer> ().sprite = bowlFull;
				} else if (fills == 2) {
						GetComponent<SpriteRenderer> ().sprite = bowl75;
				} else if (fills == 1) {
						GetComponent<SpriteRenderer> ().sprite = bowl25;
				} else if (fills == 0 && hasKey) {
						GetComponent<SpriteRenderer> ().sprite = bowlEmptyKey;
				} else {
						GetComponent<SpriteRenderer> ().sprite = bowlEmpty;
				}
		}

		public void FillUp ()
		{
				if (fills > 7)
						return;

				++fills;
				UpdateSprite ();
	
		}
}
