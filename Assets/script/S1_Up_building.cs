using UnityEngine;
using System.Collections;

public class S1_Up_building : MonoBehaviour {
	public GameObject Yuzu;
	public float heightup = 2.0f;
	private float m_speed = 1.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(heightup>0){
			transform.Translate (0,m_speed*Time.deltaTime,0);
			heightup -= Time.deltaTime;
		}
		else {
			transform.Translate(0,0,0);
			heightup=0;
		}
	}
}
