using UnityEngine;
using System.Collections;

public class FoodbagController : WithMouseActions {

	public override void PerformOnClickAction() {
		GameObject.Find ("bowl").GetComponent<BowlController> ().FillUp ();

		roomManager.AddInfoText ("Now I can eat more!");
	}
}
