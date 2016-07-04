using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Pool<T>  : MonoBehaviour where T : Pool<T> {

	public static T Instance { get; private set; }

	GameObject go;
	public List<GameObject> Array;

	Vector3 defaultVector3;
	Quaternion defaultQuaternion;

	protected virtual void Awake()
	{
		if (Instance == null)
		{
			Instance = (T) this;
			defaultVector3 = new Vector3(0,0,0);
			defaultQuaternion = new Quaternion();
		}
		else
		{
			Debug.LogError("Got a second instance of the class " + this.GetType());
		}
	}

	protected void InitPool(GameObject o, int count = 20)
	{
		go = o;
		Array = new List<GameObject>();
		for (int i = 0; i < count; i++) 
			Creare();
	}

	GameObject Creare(){
		UnityEngine.Object o = Instantiate(go, defaultVector3, defaultQuaternion);

		(o as GameObject).SetActive(false);
		Array.Add(o as GameObject);
		return o as GameObject;
	}

	public GameObject GetAviable(Transform parent){
		foreach (GameObject o in Array) {
			if (!o.activeSelf)
			{
				(o as GameObject).transform.SetParent (parent);
				return o;
			}
		}
		GameObject obj = Creare();
		(obj as GameObject).transform.SetParent (parent);
		return obj;
	}
}
