using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WindowsControllerScript : Singleton<WindowsControllerScript> {

	public List<GameObject> Windows = new List<GameObject>();

	string wrongWindowName_str = "Wrong window name:";

	// Use this for initialization
	void Start () {
		foreach (GameObject go in Windows) {
			go.SetActive(go == Windows[0]);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenWindow(string name) {
		GameObject w = Windows.FirstOrDefault (x => x.name == name);
		if (w == null) {
			Debug.LogError(string.Format("{0} {1}", wrongWindowName_str, name));
			return;
		}
		w.GetComponent<IWindow> ().InitWindow ();

		foreach (GameObject go in Windows) {
			go.SetActive(go == w);
		}
	}
}
