using UnityEngine;
using System.Collections;

public class S3_join : MonoBehaviour {
	public GameObject Up_Building;
	public GameObject ObjCon;

	//turn_brick_DS
	public GameObject S4C1;
	public GameObject S4C2;
	public GameObject S4C3;
	public GameObject S7C1;
	public GameObject S7C2;
	public GameObject S7C3;
	public GameObject S7C4;

	//0_connect_brick & up
	public GameObject N3;
	public GameObject S8C1;

	//180_connect_brick
	public GameObject N4;
	public GameObject S6C2;

	void Start(){
	}
	void Update () {
		JoinObject ();
	}
	void JoinObject(){
		if (Up_Building.GetComponent<S3_Up_building> ().heightup == 0) {
			if(ObjCon.transform.eulerAngles.y >= -10 && ObjCon.transform.eulerAngles.y <= 5){
				N3.GetComponent<DS_data>().SetLeft("S4C1");
				S4C1.GetComponent<DS_data>().SetRight("N3");
				S4C1.GetComponent<DS_data>().SetLeft("S4C2");
				S4C2.GetComponent<DS_data>().SetRight("S4C1");
				S4C2.GetComponent<DS_data>().SetLeft("S4C3");
				S4C3.GetComponent<DS_data>().SetRight("S4C2");
				S4C3.GetComponent<DS_data>().SetLeft("0");
				S7C1.GetComponent<DS_data>().SetRight("0");
				S7C1.GetComponent<DS_data>().SetLeft("S7C2");
				S7C2.GetComponent<DS_data>().SetRight("S7C1");
				S7C2.GetComponent<DS_data>().SetLeft("S7C3");
				S7C3.GetComponent<DS_data>().SetRight("S7C2");
				S7C3.GetComponent<DS_data>().SetLeft("S7C4");
				S7C4.GetComponent<DS_data>().SetRight("S7C3");
				S7C4.GetComponent<DS_data>().SetLeft("S8C1");
				S8C1.GetComponent<DS_data>().SetRight("S7C4");
			}
		}

	}
}
