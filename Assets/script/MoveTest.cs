using UnityEngine;
using System.Collections;

public class MoveTest : MonoBehaviour {

	public GameObject BrickDS; //DS_Structure

	private RaycastHit hit; //mouse.hit
	
	public float speed1 = 0.1F; // turn speed
	public float speed2 = 3.0F; // move speed
	
	public GUIText oname; 
	public GUIText oset;

	private GameObject locobject; //location Brick
	private DS_data locDS;
	private GameObject destobject; //destination Brick
	private string destname;

	private string tr; //pathR string
	private string tl; //pathL string


	void Start () {
		//FindYuzuBrick ();
		oname.text = "loc_name: "+locDS.DSname;
	}
	
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit)) {
				FindYuzuBrick ();								//Find the brick under yuzu
				destname = hit.collider.gameObject.name;
				for (int i = 0; i<BrickDS.transform.childCount; i++) 
				{
					DS_data tempD = BrickDS.transform.GetChild(i).GetComponent<DS_data>();
					if(tempD.DSname==destname) destobject = GameObject.Find(destname);
				}
			}
		}
		FindNode();
	}

	void FindNode(){
		if (locDS.right != "0"){
			tr = FindNext("L",destname,locDS.DSname,locDS.right);
			string[] PathRArray = tr.Split(',');
			if(tr !="GG"){
				for(int i=1; i<PathRArray.Length; i++){
					GameObject temp = GameObject.Find(PathRArray[i]);
					//if(temp.tag=="Node") PlayerMove(temp);
					PlayerMove(temp);
				}
			}
		}
		
		if (locDS.left != "0"){
			tl = FindNext("R",destname,locDS.DSname,locDS.left);
			string[] PathLArray = tl.Split(',');
			if(tl !="GG"){
				for(int j=1; j<PathLArray.Length; j++){
					GameObject temp = GameObject.Find(PathLArray[j]);
					//if(temp.tag=="Node") PlayerMove(temp);
					PlayerMove(temp);
				}
			}
		}
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

	void PlayerMove(GameObject dest){
		Vector3 temp;
		if (Vector3.Distance(transform.position,dest.transform.position)>0.1) {
			animation.Play("run");
			animation.wrapMode = WrapMode.Loop;
			temp = new Vector3(dest.transform.position.x, transform.position.y, dest.transform.position.z);
			turn (temp);
			move ();
		}
		else {
			animation.Play("idle");
			animation.wrapMode = WrapMode.Loop;
		}
		//Transform HitT = hit.collider.gameObject.transform;
		//if (HitT.position.y != transform.position.y)
		//	transform.position = new Vector3 (transform.position.x,HitT.position.y,transform.position.z);
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

}