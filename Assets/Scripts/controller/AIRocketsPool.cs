using UnityEngine;
using System.Collections;

public class AIRocketsPool : Pool<AIRocketsPool> {

	public GameObject aiRocket;

	// Use this for initialization
	void Start () {
		InitPool (aiRocket);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
