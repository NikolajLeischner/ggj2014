var slot :Transform;
var xtemp;
var ytemp;

function OnMouseUp(){
	if (Vector3.Distance(transform.position,slot.position)==1)  {
		xtemp=transform.position.x;
		ytemp=transform.position.y;
		transform.position.x=slot.position.x;
		transform.position.y=slot.position.y;
		slot.position.x=xtemp;
		slot.position.y=ytemp;
		}
}
