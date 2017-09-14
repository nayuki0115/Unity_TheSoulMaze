using UnityEngine;
using System.Collections;

public class S4_join : MonoBehaviour {
	public GameObject Up_Turn;
	public GameObject Up_Building;
	public GameObject ObjCon;

	//turn_brick_DS
	public GameObject S2C1;
	public GameObject S2C2;
	public GameObject S2C3;
	public GameObject N1;
	public GameObject S3C1;
	public GameObject S3C2;
	public GameObject S3C3;

	//1_floor_connect_brick
	public GameObject S1C2;
	public GameObject S4C1;
	public GameObject N4;

	//2_floor_connect_brick
	public GameObject N6;
	public GameObject N7;
	public GameObject S9C1;
	public GameObject S12C2;

	public GUIText oname;

	void Start(){
	}
	void Update () {
		JoinObject ();
	}
	void JoinObject(){
		if(!Up_Turn.GetComponent<S4_Up_turn>().enabled){
			if(ObjCon.transform.eulerAngles.y >= 265 && ObjCon.transform.eulerAngles.y <= 275){
				S1C2.GetComponent<DS_data>().SetLeft("S2C1");
				S2C1.GetComponent<DS_data>().SetRight("S1C2");
				S2C1.GetComponent<DS_data>().SetLeft("S2C2");
				S2C2.GetComponent<DS_data>().SetRight("S2C1");
				S2C2.GetComponent<DS_data>().SetLeft("S2C3");
				S2C3.GetComponent<DS_data>().SetRight("S2C2");
				S2C3.GetComponent<DS_data>().SetLeft("N1");
				N1.GetComponent<DS_data>().SetRight("S2C3");
				N1.GetComponent<DS_data>().SetLeft("S3C1");
				S3C1.GetComponent<DS_data>().SetRight("N1");
				S3C1.GetComponent<DS_data>().SetLeft("S3C2");
				S3C2.GetComponent<DS_data>().SetRight("S3C1");
				S3C2.GetComponent<DS_data>().SetLeft("S3C3");
				S3C3.GetComponent<DS_data>().SetRight("S3C2");
				S3C3.GetComponent<DS_data>().SetLeft("0");
				if(Up_Building.GetComponent<S4_Up_building>().heightup==0){
					S3C3.GetComponent<DS_data>().SetLeft("N4");
					N4.GetComponent<DS_data>().SetUP("S3C3");
				}
			}
			if(ObjCon.transform.eulerAngles.y >= 175 && ObjCon.transform.eulerAngles.y <= 185){
				S4C1.GetComponent<DS_data>().SetRight("S2C1");
				S1C2.GetComponent<DS_data>().SetLeft("S3C3");
				S2C1.GetComponent<DS_data>().SetRight("S2C2");
				S2C1.GetComponent<DS_data>().SetLeft("S4C1");
				S2C2.GetComponent<DS_data>().SetRight("S2C3");
				S2C2.GetComponent<DS_data>().SetLeft("S2C1");
				S2C3.GetComponent<DS_data>().SetRight("N1");
				S2C3.GetComponent<DS_data>().SetLeft("S2C2");
				N1.GetComponent<DS_data>().SetRight("S3C1");
				N1.GetComponent<DS_data>().SetLeft("S2C3");
				S3C1.GetComponent<DS_data>().SetRight("S3C2");
				S3C1.GetComponent<DS_data>().SetLeft("N1");
				S3C2.GetComponent<DS_data>().SetRight("S3C3");
				S3C2.GetComponent<DS_data>().SetLeft("S3C1");
				S3C3.GetComponent<DS_data>().SetRight("S1C2");
				S3C3.GetComponent<DS_data>().SetLeft("S3C2");
			}
			if(ObjCon.transform.eulerAngles.y >= 85 && ObjCon.transform.eulerAngles.y <= 95){
				S2C1.GetComponent<DS_data>().SetRight("0");
				S2C1.GetComponent<DS_data>().SetLeft("S2C2");
				S2C2.GetComponent<DS_data>().SetRight("S2C1");
				S2C2.GetComponent<DS_data>().SetLeft("S2C3");
				S2C3.GetComponent<DS_data>().SetRight("S2C2");
				S2C3.GetComponent<DS_data>().SetLeft("N1");
				N1.GetComponent<DS_data>().SetRight("S2C3");
				N1.GetComponent<DS_data>().SetLeft("S3C1");
				S3C1.GetComponent<DS_data>().SetRight("N1");
				S3C1.GetComponent<DS_data>().SetLeft("S3C2");
				S3C2.GetComponent<DS_data>().SetRight("S3C1");
				S3C2.GetComponent<DS_data>().SetLeft("S3C3");
				S3C3.GetComponent<DS_data>().SetRight("S3C2");
				S3C3.GetComponent<DS_data>().SetLeft("S4C1");
				S4C1.GetComponent<DS_data>().SetRight("S3C3");
			}
			if(ObjCon.transform.eulerAngles.y >= -10 && ObjCon.transform.eulerAngles.y <= 5){
				N4.GetComponent<DS_data>().SetRight("S2C1");
				S1C2.GetComponent<DS_data>().SetLeft("S3C3");
				S2C1.GetComponent<DS_data>().SetRight("S2C2");
				S2C1.GetComponent<DS_data>().SetLeft("N4");
				S2C2.GetComponent<DS_data>().SetRight("S2C3");
				S2C2.GetComponent<DS_data>().SetLeft("S2C1");
				S2C3.GetComponent<DS_data>().SetRight("N1");
				S2C3.GetComponent<DS_data>().SetLeft("S2C2");
				N1.GetComponent<DS_data>().SetRight("S3C1");
				N1.GetComponent<DS_data>().SetLeft("S2C3");
				S3C1.GetComponent<DS_data>().SetRight("S3C2");
				S3C1.GetComponent<DS_data>().SetLeft("N1");
				S3C2.GetComponent<DS_data>().SetRight("S3C3");
				S3C2.GetComponent<DS_data>().SetLeft("S3C1");
				S3C3.GetComponent<DS_data>().SetRight("S1C2");
				S3C3.GetComponent<DS_data>().SetLeft("S3C2");
			}
		}

		if (Up_Turn.GetComponent<S4_Up_turn>().enabled && Up_Turn.GetComponent<S4_Up_turn>().heightup==0) {
			if(ObjCon.transform.eulerAngles.y >= 265 && ObjCon.transform.eulerAngles.y <= 275){
				S12C2.GetComponent<DS_data>().SetLeft("S2C1");
				S2C1.GetComponent<DS_data>().SetRight("S12C2");
				S2C1.GetComponent<DS_data>().SetLeft("S2C2");
				S2C2.GetComponent<DS_data>().SetRight("S2C1");
				S2C2.GetComponent<DS_data>().SetLeft("S2C3");
				S2C3.GetComponent<DS_data>().SetRight("S2C2");
				S2C3.GetComponent<DS_data>().SetLeft("N1");
				N1.GetComponent<DS_data>().SetRight("S2C3");
				N1.GetComponent<DS_data>().SetLeft("S3C1");
				S3C1.GetComponent<DS_data>().SetRight("N1");
				S3C1.GetComponent<DS_data>().SetLeft("S3C2");
				S3C2.GetComponent<DS_data>().SetRight("S3C1");
				S3C2.GetComponent<DS_data>().SetLeft("S3C3");
				S3C3.GetComponent<DS_data>().SetRight("S3C2");
				S3C3.GetComponent<DS_data>().SetLeft("S9C1");
				S9C1.GetComponent<DS_data>().SetRight("S3C3");
			}
			if(ObjCon.transform.eulerAngles.y >= 175 && ObjCon.transform.eulerAngles.y <= 185){
				S12C2.GetComponent<DS_data>().SetLeft("S3C3");
				S3C3.GetComponent<DS_data>().SetRight("S12C2");
				S3C3.GetComponent<DS_data>().SetLeft("S3C2");
				S3C2.GetComponent<DS_data>().SetRight("S3C3");
				S3C2.GetComponent<DS_data>().SetLeft("S3C1");
				S3C1.GetComponent<DS_data>().SetRight("S3C2");
				S3C1.GetComponent<DS_data>().SetLeft("N1");
				N1.GetComponent<DS_data>().SetRight("S3C1");
				N1.GetComponent<DS_data>().SetLeft("S2C3");
				S2C3.GetComponent<DS_data>().SetRight("N1");
				S2C3.GetComponent<DS_data>().SetLeft("S2C2");
				S2C2.GetComponent<DS_data>().SetRight("S2C3");
				S2C2.GetComponent<DS_data>().SetLeft("S2C1");
				S2C1.GetComponent<DS_data>().SetRight("S2C2");
				S2C1.GetComponent<DS_data>().SetLeft("0");

			}
			if(ObjCon.transform.eulerAngles.y >= 85 && ObjCon.transform.eulerAngles.y <= 95){
				N7.GetComponent<DS_data>().SetLeft("S2C1");
				S2C1.GetComponent<DS_data>().SetRight("N7");
				S2C1.GetComponent<DS_data>().SetLeft("S2C2");
				S2C2.GetComponent<DS_data>().SetRight("S2C1");
				S2C2.GetComponent<DS_data>().SetLeft("S2C3");
				S2C3.GetComponent<DS_data>().SetRight("S2C2");
				S2C3.GetComponent<DS_data>().SetLeft("N1");
				N1.GetComponent<DS_data>().SetRight("S2C3");
				N1.GetComponent<DS_data>().SetLeft("S3C1");
				S3C1.GetComponent<DS_data>().SetRight("N1");
				S3C1.GetComponent<DS_data>().SetLeft("S3C2");
				S3C2.GetComponent<DS_data>().SetRight("S3C1");
				S3C2.GetComponent<DS_data>().SetLeft("S3C3");
				S3C3.GetComponent<DS_data>().SetRight("S3C2");
				S3C3.GetComponent<DS_data>().SetLeft("S9C1");
			}
			if(ObjCon.transform.eulerAngles.y >= -10 && ObjCon.transform.eulerAngles.y <= 5){
				Debug.Log(ObjCon.transform.eulerAngles.y);
				N7.GetComponent<DS_data>().SetLeft("S3C3");
				S3C3.GetComponent<DS_data>().SetRight("N7");
				S3C3.GetComponent<DS_data>().SetLeft("S3C2");
				S3C2.GetComponent<DS_data>().SetRight("S3C3");
				S3C2.GetComponent<DS_data>().SetLeft("S3C1");
				S3C1.GetComponent<DS_data>().SetRight("S3C2");
				S3C1.GetComponent<DS_data>().SetLeft("N1");
				N1.GetComponent<DS_data>().SetRight("S3C1");
				N1.GetComponent<DS_data>().SetLeft("S2C3");
				S2C3.GetComponent<DS_data>().SetRight("N1");
				S2C3.GetComponent<DS_data>().SetLeft("S2C2");
				S2C2.GetComponent<DS_data>().SetRight("S2C3");
				S2C2.GetComponent<DS_data>().SetLeft("S2C1");
				S2C1.GetComponent<DS_data>().SetRight("S2C2");
				S2C1.GetComponent<DS_data>().SetLeft("S9C1");
				S9C1.GetComponent<DS_data>().SetRight("S2C1");
			}
		}

	}
}
