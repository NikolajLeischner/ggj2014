using UnityEngine;
using System.Collections;

public class Inventory {
	
	ArrayList items = new ArrayList ();
	ArrayList freePositions = new ArrayList ();

	InventoryItem activeItem = null;
	
	public Inventory(ArrayList initialPositions) {
		freePositions = initialPositions;
	}
	
	public void SetItemActive (InventoryItem item)
	{
		if (activeItem != null) {
			activeItem.SetActive(false);		
		}
		activeItem = item;
		activeItem.SetActive (true);
		
	}
	
	public void AddItemToInventory (InventoryItem item)
	{
		if (freePositions.Count == 0) {
			MonoBehaviour.print ("Inventory full!");
			return;		
		}
		if (items.IndexOf (item) == -1) {
			items.Add (item);
			int last = freePositions.Count - 1;
			Vector3 position = (Vector3) freePositions[last];
			item.transform.position = position;
			freePositions.Remove (last);
		} else {
			MonoBehaviour.print ("Item is already in the inventory");
		}
	}
	
	public void RemoveItemFromInventory (InventoryItem item)
	{
		int id = items.IndexOf (item);
		if (id != -1) {
			Vector3 position = item.transform.position;
			freePositions.Add (position);
			// TODO: Do we need to re-add things to the room? Currently just moving the item out of the way.
			item.transform.position = new Vector3 (-100, -100, -100);
			items.Remove (id);

			if (item.IsActive()) {
				item.SetActive (false);
				activeItem = null;
			}
		}
	}
	
}