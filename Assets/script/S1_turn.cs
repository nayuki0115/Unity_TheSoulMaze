using UnityEngine;
using System.Collections;

public class S1_turn : MonoBehaviour {
	private bool oo=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//oo = true;
		if(oo==true) transform.Rotate (0, 0, 90);
		oo = false;
	}
}
