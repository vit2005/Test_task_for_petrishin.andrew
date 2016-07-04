using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MovingObject  {

	public static List<MovingObject> MovingObjects = new List<MovingObject>();
	public static List<MovingObject> StopeedObjects = new List<MovingObject> ();

	//static readonly Vector3 delta = new Vector3 (0, -1, 0);

	public Transform target;
	Vector3 delta;
	bool? islethal;

	public void Move(){
		if (!target.gameObject.activeSelf) {
			StopeedObjects.Add (this);
			return;
		}

		target.localPosition += delta;		
	}

	public MovingObject(Vector3 pos1, Vector3 pos2, GameObject target, bool isPlayerBullet = true, float speed = 1)
	{
		delta = pos2 - pos1;
		float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

		this.target = target.transform;
		this.target.position = pos1;
		this.target.gameObject.SetActive (true);
		this.target.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


		float x = (delta.x / (Mathf.Abs(delta.x) + Mathf.Abs(delta.y))) * speed;
		float y = (delta.y / (Mathf.Abs(delta.x) + Mathf.Abs(delta.y))) * speed;
		delta = new Vector3(x,y,0);

		if (isPlayerBullet) {
			float lethalx = (pos2.x * pos1.y - pos1.x * pos2.y) / (pos1.y - pos2.y); //http://www.math.by/geometry/eqline.html
			islethal = lethalx > 0 && lethalx < Screen.width;
			Debug.Log ("islethal = " + islethal + "; lethalx = " + lethalx);
		} else
			islethal = null;

		if (MovingObjects.FirstOrDefault (t => t.target == target) != null)
			return;
		MovingObjects.Add (this);
	}
}
