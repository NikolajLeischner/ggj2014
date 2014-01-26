using UnityEngine;
using System.Collections;

public class CannonController : WithMouseActions {

	public Sprite cannonFired;
	public Sprite cannonBurning;

	public Vector3 barrelPosition;
	public Vector3 targetPosition;
	bool wasTriggered = false;
	
	public override void PerformOnClickAction ()
	{
		GameObject ballObject = GameObject.Find ("cannon_ball");
		InventoryItem ball = ballObject.GetComponent<InventoryItem> ();
		if (!wasTriggered && ball.IsInInventory()) {
			wasTriggered = true;
			ball.RemoveFromInventory();
			ballObject.transform.position = barrelPosition;
			StartCoroutine (ShootAtGuard (targetPosition, ballObject));
		}
		
	}
	
	IEnumerator ShootAtGuard (Vector3 target, GameObject projectile)
	{
		GetComponent<SpriteRenderer> ().sprite = cannonBurning;
		yield return new WaitForSeconds(2.0f);
		GetComponent<SpriteRenderer> ().sprite = cannonFired;

		float speed = 3.0f;

		while (Vector3.Distance(projectile.transform.position, target) > 0.05f) {
			projectile.transform.position = Vector3.Lerp (projectile.transform.position, target, speed * Time.deltaTime);
			
			yield return null;
		}
		
		print ("Reached the target.");
		GuardController guard = GameObject.Find ("guard").GetComponent<GuardController> ();
		guard.Destroy ();
		projectile.SetActive (false);
	}
}
