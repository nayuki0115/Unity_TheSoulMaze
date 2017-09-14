using UnityEngine;
using System.Collections;

public class Click_Point : MonoBehaviour {
	//public GameObject player;
	public GameObject[] path;
	public GameObject pathdata;
	public GameObject BrickDS;
	
	private Vector3 temp;
	private RaycastHit hit;
	private Vector3 point;
	
	public float speed1 = 0.0F;
	public float speed2 = 3.0F;

	public GUIText oname;//object name
	public GUIText oset;//object set

	private GameObject tempobject;
	private GameObject locobject;
	private string destname = "";
	private string leftname = "";
	private string rightname = "";
	
	void Start () {
		//oname.color= Color.green;
		//oset.color= Color.green;
	}
	
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit)) {
				destname = hit.collider.gameObject.name;
				FindName(destname);
				oname.text="Name: "+destname+", Left: "+leftname+", Right: "+rightname;
				//oset.text="Set: "+hit.collider.gameObject.transform.parent.name;
				oset.text="Yuzu: "+locobject.name;
				animation.Play("run");
				animation.wrapMode = WrapMode.Loop;
			}
		}
		FindYuzu ();
		PlayerMove ();

	}
	void PlayerMove(){
		for(int j=0; j<path.Length; j++){
			for(int i=0; i<path[j].transform.childCount; i++){
				GameObject HitG = hit.collider.gameObject;
				GameObject PCG = path[j].transform.GetChild(i).gameObject;
				if (HitG == PCG && Vector3.Distance(transform.position,HitG.transform.position)>0.1) {
					temp = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
					turn (temp);
					move ();
				}

				else if(HitG != PCG && Vector3.Distance(transform.position,HitG.transform.position)<=0.1){
					animation.Play("idle");
					animation.wrapMode = WrapMode.Loop;
				}
			}
		}
		Transform HitT = hit.collider.gameObject.transform;
		if (HitT.position.y != transform.position.y)
			transform.position = new Vector3 (transform.position.x,HitT.position.y,transform.position.z);
	}

	/*void FindYuzu(){
		for (int i = 0; i<BrickDS.transform.childCount; i++) {
			DS_data loc = BrickDS.transform.GetChild (i).GetComponent<DS_data>();
			
			for(int j=0; j<pathdata.transform.childCount; j++){
				Transform pathChild = pathdata.transform.GetChild(j);
				for(int k=0; k<pathChild.transform.childCount; k++){
					if (loc.DSname == pathChild.name)
						loctran = pathChild.transform;
					else if (loc.DSname == pathChild.transform.GetChild(k).name)
						loctran = pathChild.transform.GetChild(k).transform;
				}
			}
		}
	}*/
	void FindYuzu(){
		int DS_length = BrickDS.transform.childCount;
		float[] dis = new float[DS_length];
		for (int i = 0; i<DS_length; i++) {						//how many Chilhren of DS_Structure
			DS_data loc = BrickDS.transform.GetChild(i).GetComponent<DS_data>();   
			tempobject = GameObject.Find(loc.DSname);								//Find the name(loc.DSname) of gameobject in this project
			dis[i]=Vector3.Distance(transform.position,tempobject.transform.position);
		}
		
		float min = dis [0];
		for (int j = 0; j<DS_length; j++) {
			if(dis[j]<min){
				min=dis[j];
				locobject = GameObject.Find(BrickDS.transform.GetChild(j).GetComponent<DS_data>().DSname);
			}
			//if(dis[j]>max) max=dis[j];
		}
	}


	void turn(Vector3 temp){
		Quaternion PlayerRo=Quaternion.LookRotation(temp-transform.position,Vector3.up);
		transform.rotation = Quaternion.Lerp (PlayerRo, transform.rotation, Time.deltaTime*speed1);
	}

	void move(){
		transform.Translate(Vector3.forward * Time.deltaTime * speed2);
	}

	void FindName(string brickname)
	{
		for (int i = 0; i<BrickDS.transform.childCount; i++) 
		{
			if(BrickDS.transform.GetChild(i).name==("DS_"+brickname))
			{
				DS_data scp = BrickDS.transform.GetChild(i).GetComponent<DS_data>();
				leftname = scp.left;
				rightname = scp.right;
			}
			
		}
	}
}
