using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {

	protected virtual void PerformClickAction() {
		print ("I was clicked..");
		}

	void Update () {
		if (Input.GetMouseButton (0)) {  
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if (hit.collider != null) { 
				print ("hit");
				if (hit.collider.gameObject == this.gameObject) {
					PerformClickAction ();
				}
			}
		} 

	
	}
}
