using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : Singleton<MenuScript>, IWindow {

	public Button play_btn;
	public Button exit_btn;

	// Use this for initialization
	void Start () {
		play_btn.onClick.AddListener (PlayBtnClick);
		exit_btn.onClick.AddListener (ExitBtnClick);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitWindow() {

		Debug.Log ("Menu initiated");
	}

	void PlayBtnClick() {
		WindowsControllerScript.Instance.OpenWindow ("Battlefield");
	}

	void ExitBtnClick()	{
		Debug.Log("Application closed");
		Application.Quit ();
	}
}
