using UnityEngine;
using System.Collections;

public class PlayerRocketsPool : Pool<PlayerRocketsPool> {

	public GameObject playerRocket;

	// Use this for initialization
	void Start () {
		InitPool (playerRocket);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}