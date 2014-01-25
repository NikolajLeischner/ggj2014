using UnityEngine;
using System.Collections;

public class Dummy : WithMouseActions {

	public override void PerformOnClickAction() {

		print ("Dummy was clicked");

		roomManager.MoveToNextRoom ();
	}
}
