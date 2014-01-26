using UnityEngine;
using System.Collections;

public class BarrelController : WithMouseActions
{
	public Sprite barrelWhole;
	public Sprite barrelIcecube; // ice cube
	public Sprite barrelMelted;
	bool broken = false;
	public bool melted = false;
	public bool keyTaken = false;

	public override void PerformOnClickAction ()
	{
		roomManager.AddInfoText ("More!");

		if (!broken && !melted) {
						roomManager.AddInfoText ("It's a barrel of water");
				} else if (broken && !melted) {
						roomManager.AddInfoText ("There's a key inside, I wonder how to get it out?");
				} else if (broken && melted && !keyTaken) {
						keyTaken=true;
						GameObject.Find ("key").GetComponent<InventoryItem> ().InsertIntoInventory ();
						enabled=false;
			GetComponent<SpriteRenderer>().sprite = null;
				} else if (broken && melted && keyTaken) {
				}
	}

	public void burst() {
		GetComponent<SpriteRenderer> ().sprite = barrelIcecube;
		broken = true;
	}

	public void melt() {
		GetComponent<SpriteRenderer> ().sprite = barrelMelted;
		GetComponent<Transform> ().localScale = new Vector3 (1, 1, 1);
		melted = true;
	}

}