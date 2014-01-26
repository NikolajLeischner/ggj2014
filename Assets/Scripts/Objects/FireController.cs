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
		}

		void UpdateSprite ()
		{
				if (fills >= 3) {
						GetComponent<SpriteRenderer> ().sprite = fireFull;
				} else if (fills == 2) {
						GetComponent<SpriteRenderer> ().sprite = fire75;
				} else if (fills == 1) {
						GetComponent<SpriteRenderer> ().sprite = fire25;
				} else if (fills == 0) {
						GetComponent<SpriteRenderer> ().sprite = fireEmpty;
				} else {
						GetComponent<SpriteRenderer> ().sprite = fireEmpty;
				}
		}

		public void FireUp ()
		{
				if (fills == 2) {
					gettingColder=true;
					if(!barrel.keyTaken)
						barrel.melt();
				}

				++fills;
				UpdateSprite ();
	
		}

		public void FireDown ()
		{
				if (fills == 1) {
					gettingColder=false;
					if(!barrel.melted)
						barrel.burst();
				}
			
				--fills;
				UpdateSprite ();
			
		}
}
