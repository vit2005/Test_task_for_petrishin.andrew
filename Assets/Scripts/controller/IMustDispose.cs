using UnityEngine;
using System.Collections;

// this class uses for bullets
public class IMustDispose : MonoBehaviour {

	float width;
	float height;

	public void Start () {
		width = transform.parent.GetComponent<RectTransform> ().sizeDelta.x / 2 ;
		height = transform.parent.GetComponent<RectTransform> ().sizeDelta.y / 2 ;
	}

	public void Update () {
		if (System.Math.Abs (transform.localPosition.x) > width || System.Math.Abs (transform.localPosition.y) > height)
			gameObject.SetActive (false);
	}
}
