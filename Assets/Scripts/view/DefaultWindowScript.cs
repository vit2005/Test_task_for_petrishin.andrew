using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DefaultWindowScript : MonoBehaviour {



	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3(gameObject.transform.parent.position.x, gameObject.transform.parent.position.y, 0);
		transform.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
	}
}
