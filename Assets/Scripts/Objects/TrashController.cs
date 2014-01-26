using UnityEngine;
using System.Collections;

public class TrashController : WithMouseActions
{
	
		public Sprite whole;
		public Sprite broken;
	
		void Start ()
		{
				GetComponent<SpriteRenderer> ().sprite = whole;
		}
	
		public override void PerformOnClickAction ()
		{
				base.PerformOnClickAction ();
		
				GetComponent<SpriteRenderer> ().sprite = broken;
				GameObject pin = GameObject.Find ("pin");

				InventoryItem item = pin.GetComponent<InventoryItem> ();
				if (!item.IsInInventory ()) {
						pin.transform.position = new Vector3 (-2.83f, -2.543f, 0.0f);
				}

		}
}