﻿using UnityEngine;
using System.Collections;

public class S4_Up_building : MonoBehaviour {
	public float heightup = 4.0f;
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
