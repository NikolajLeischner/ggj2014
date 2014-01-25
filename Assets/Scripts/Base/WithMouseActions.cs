using UnityEngine;
using System.Collections;

public class WithMouseActions : MonoBehaviour {

	public virtual void PerformOnClickAction() {
		print ("I was clicked..");
	}
	public virtual void PerformOnHoverAction() {
		print ("hovering..");
	}
}
