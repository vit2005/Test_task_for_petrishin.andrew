using UnityEngine;
using System.Collections;

public class BattlefieldScript : Singleton<BattlefieldScript>, IWindow {

	public Transform Target;
	float theTime;
	float nextAIFireTime = 1;

	float ScreenWidthHalf;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			setTarget(Input.mousePosition);
			Debug.Log(string.Format("[{0};{1}]",Input.mousePosition.x,Input.mousePosition.y));
		}
		FireAI ();
		MoveMovingObjects ();
	}

	public void InitWindow() {
		theTime = Time.time;

		Debug.Log ("Battlefield initiated");
	}

	void setTarget(Vector3 pos) {
		Target.gameObject.SetActive (true);
		Target.position = pos;		
		float r = Random.Range (10, Screen.width);
		//Debug.Log(r);
		new MovingObject (new Vector3(r,Screen.height - 30,0), pos, PlayerRocketsPool.Instance.GetAviable(this.transform));
	}

	void MoveMovingObjects() {

		foreach (MovingObject item in MovingObject.StopeedObjects) {
			MovingObject.MovingObjects.Remove(item);
		}
		MovingObject.StopeedObjects = new System.Collections.Generic.List<MovingObject> ();
		foreach (MovingObject item in MovingObject.MovingObjects) {
			item.Move();
		}
		
	}

	void FireAI(){
		if(Time.time - theTime > nextAIFireTime) {
			theTime = Time.time; 
			Calculate();
		}
	}

	//http://www.gamedev.ru/community/123/articles/?id=1062
	//http://pmg.org.ru/nehe/nehe30.htm
	//https://habrahabr.ru/post/200516/
	void Calculate (){}
}
