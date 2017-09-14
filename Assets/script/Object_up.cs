using UnityEngine;
using System.Collections;

public class Object_up : MonoBehaviour {
	public GameObject appear_obj;
	public float heightup = 4.0f;
	private float m_speed = 1.0f;
	// Use this for initialization
	void Start () {
		appear_obj.gameObject.SetActive(false);
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

		if (transform.position.y >= 0)
			appear_obj.gameObject.SetActive(true);
	}
}
