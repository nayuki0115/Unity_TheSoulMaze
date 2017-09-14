﻿using UnityEngine;
using System.Collections;

public class S4_Yuzu_move : MonoBehaviour {
	public GameObject Goal;
	public GameObject BrickDS;
	public GameObject ObjCon;
	public GameObject object1;
	public GameObject object2;
	public GameObject set2;
	public GameObject set3;
	public GameObject node1;
	public GameObject btn1;
	public GameObject btn2;
	public GameObject Up_building;
	public GameObject Up_turn;

	private RaycastHit hit; //mouse.hit
	
	public float speed1 = 0.1F; // turn speed
	public float speed2 = 3.0F; // move speed
	
	public GUIText oname; 
	public GUIText oset;
	
	private DS_data locDS;
	//private GameObject locobject;
	private string destname;
	private GameObject destobject;
	private GameObject locobject;

	private string tr; //pathR string
	private string tl; //pathL string
	private string tempString;
	private int num = 0;

	void Start () {
		FindYuzuBrick ();
	}
	
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit)) {
				FindYuzuBrick ();								//Find the brick under yuzu
				destname = hit.collider.gameObject.name;
				destobject = GameObject.Find(destname); 
				tempString = FindNode();
				num=0;
			}
		}
		PlayerMove (tempString);

		if(Vector3.Distance(transform.position,btn1.transform.position)<=0.1)
			Up_building.GetComponent<S4_Up_building>().enabled=true;
		if(Vector3.Distance(transform.position,btn2.transform.position)<=0.1)
			Up_turn.GetComponent<S4_Up_turn>().enabled=true;
		if (Vector3.Distance (transform.position, Goal.transform.position) <= 0.1)
			oname.gameObject.SetActive (true);

		turn_close ();

	}

	string FindNode(){
		if (locDS.right != "0"){
			tr = FindNext("L",destname,locDS.DSname,locDS.right);
			if(tr !="GG") return tr;
		}
		
		if (locDS.left != "0"){
			tl = FindNext("R",destname,locDS.DSname,locDS.left);
			if(tl !="GG") return tl;
		}
		return "";
	}
	
	void FindYuzuBrick(){
		float distance = 10000;
		int index = -1;
		int DS_length = BrickDS.transform.childCount;
		for (int i = 0; i<DS_length; i++) {						//how many Chilhren of DS_Structure
			DS_data loc = BrickDS.transform.GetChild(i).GetComponent<DS_data>();   
			GameObject tempobject = GameObject.Find(loc.DSname);			//Find the name(loc.DSname) of gameobject in this project
			float dd = Vector3.Distance(transform.position,tempobject.transform.position);
			if(distance>dd)
			{
				distance = dd;
				index = i;
			}
		}
		locDS = BrickDS.transform.GetChild(index).GetComponent<DS_data>();
		locobject = GameObject.Find (locDS.DSname);
	}

	void PlayerMove(string tempPath){
		float height = 2.0f;
		float m_speed = 2.0f;
		string[] PathArray=tempPath.Split(',');
		string[] PathNode=new string[30];
		int index = 0;
		for (int i=1; i<PathArray.Length; i++) {
			GameObject node = GameObject.Find(PathArray[i]);
			if(node.tag=="Node" || i==PathArray.Length-1){
				PathNode[index]=PathArray[i];
				index++;
			}
		}


		if(num < index){
			GameObject node = GameObject.Find(PathNode[num]);
			/*GameObject nodenext=null;
			if(num+1 < PathNode.Length) nodenext = GameObject.Find(PathNode[num+1]);
			else nodenext=null;*/

			if (Vector3.Distance(transform.position,node.transform.position)>0.1) {
				animation.Play("run");
				animation.wrapMode = WrapMode.Loop;

				if(node.transform.position.y != transform.position.y){
					if(node.transform.position.y < transform.position.y){
						if(height > 0){
							transform.Translate (0, -m_speed*Time.deltaTime,0);
							height -= Time.deltaTime;
							oset.text="height: "+height.ToString();
						}
					}
					if(node.transform.position.y > transform.position.y){
						//transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z+1);
						if(height > 0){
							transform.Translate (0, m_speed*Time.deltaTime,0);
							height -= Time.deltaTime;
							oset.text="height: "+height.ToString();
						}
					}
				}
				if(Mathf.Abs(transform.position.y-node.transform.position.y)>5){
					if(node.transform.position.y != transform.position.y){
						transform.position=new Vector3(node.transform.position.x, node.transform.position.y, node.transform.position.z);
					}
				}

				Vector3 temp = new Vector3(node.transform.position.x, transform.position.y, node.transform.position.z);
				turn (temp);
				//transform.LookAt(temp);
				move ();
			}
			else num++;
		}
		else {
			animation.Play("idle");
			animation.wrapMode = WrapMode.Loop;
		}
	}

	string FindNext (string FromDir, string Dest, string From, string Neighbor){
		GameObject ObjectNei = GameObject.Find ("DS_"+Neighbor);
		DS_data DSNeig = ObjectNei.GetComponent<DS_data> ();

		if (From == Dest) return Dest;

		else if(Neighbor == Dest) return From+","+Neighbor;

		else if(From == "0") return "GG";

		else {
			if(FromDir=="R"){
				string abc, tabc;
				if(DSNeig.left == Dest) return From+","+Neighbor+","+Dest;
				else if(DSNeig.left != "0" && DSNeig.left != From){
					abc = FindNext("R",Dest,DSNeig.DSname,DSNeig.left);
					if(abc=="GG") return "GG";
					else{
						tabc = From+","+abc;
						return tabc;
					}
				}
			}

			if(FromDir=="L"){
				string efg, tefg;
				if(DSNeig.right == Dest) return From+","+Neighbor+","+Dest;
				else if(DSNeig.right != "0" && DSNeig.right != From){
					efg = FindNext("L",Dest,DSNeig.DSname,DSNeig.right);
					if(efg=="GG") return "GG";
					else{
						tefg = From+","+efg;
						return tefg;
					}
				}
			}
			if(FromDir=="U"){
				string efg, tefg;
				if(DSNeig.right == Dest) return From+","+Neighbor+","+Dest;
				else if(DSNeig.right != "0" && DSNeig.right != From){
					efg = FindNext("U",Dest,DSNeig.DSname,DSNeig.right);
					if(efg=="GG") return "GG";
					else{
						tefg = From+","+efg;
						return tefg;
					}
				}
			}
		}
		return "GG";
	}

	void turn(Vector3 temp){
		Quaternion PlayerRo=Quaternion.LookRotation(temp-transform.position,Vector3.up);
		transform.rotation = Quaternion.Lerp (PlayerRo, transform.rotation, Time.deltaTime*speed1);
	}
	
	void move(){
		transform.Translate(Vector3.forward * Time.deltaTime * speed2);
	}

	void turn_close(){
		for(int i=0; i<set2.transform.childCount; i++){
			Transform cube = set2.transform.GetChild(i);
			if(locobject.transform == cube || destobject.transform == cube ) {
				//object1.transform.localScale= new Vector3(0.15f,0.15f,0.254f);
				//object2.transform.localScale= new Vector3(0.15f,0.15f,0.254f);
				ObjCon.GetComponent<S4_RotateY>().enabled=false;
			}
			else{
				//object1.transform.localScale= new Vector3(0.254f,0.254f,0.254f);
				//object2.transform.localScale= new Vector3(0.254f,0.254f,0.254f);
				ObjCon.GetComponent<S4_RotateY>().enabled=true;
			}
		}

		if(locobject == node1 || destobject == node1 ) {
			//object1.transform.localScale= new Vector3(0.15f,0.15f,0.254f);
			//object2.transform.localScale= new Vector3(0.15f,0.15f,0.254f);
			ObjCon.GetComponent<S4_RotateY>().enabled=false;
		}
		else{
			//object1.transform.localScale= new Vector3(0.254f,0.254f,0.254f);
			//object2.transform.localScale= new Vector3(0.254f,0.254f,0.254f);
			ObjCon.GetComponent<S4_RotateY>().enabled=true;
		}
		
		for(int i=0; i<set3.transform.childCount; i++){
			Transform cube = set3.transform.GetChild(i);
			if(locobject.transform == cube || destobject.transform==cube ) {
				//object1.transform.localScale= new Vector3(0.15f,0.15f,0.254f);
				//object2.transform.localScale= new Vector3(0.15f,0.15f,0.254f);
				ObjCon.GetComponent<S4_RotateY>().enabled=false;
			}
			else{
				//object1.transform.localScale= new Vector3(0.254f,0.254f,0.254f);
				//object2.transform.localScale= new Vector3(0.254f,0.254f,0.254f);
				ObjCon.GetComponent<S4_RotateY>().enabled=true;
			}
		}

	}
}