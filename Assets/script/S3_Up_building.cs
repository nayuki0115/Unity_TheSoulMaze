using UnityEngine;
using System.Collections;

public class S3_Up_building : MonoBehaviour {
	public GameObject Yuzu;
	public GameObject N3;
	public float heightup = 3.0f;
	private float m_speed = 1.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (heightup < 2 && heightup >= 0) {
			//Yuzu.transform.position=new Vector3(Yuzu.transform.position.x,transform.position.y+1,Yuzu.transform.position.z);
			N3.transform.position=new Vector3(N3.transform.position.x,transform.position.y+1,N3.transform.position.z);
		}
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

