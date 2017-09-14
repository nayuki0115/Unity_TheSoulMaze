using UnityEngine;
using System.Collections;

public class Rotate_choose : MonoBehaviour {

	public GameObject obj_choose =null; 
	Vector2 m_screenpos=new Vector2(); //記錄手指觸控的位置
	private Transform obj_tran;
	public float R_weight=5.0f;

	// Use this for initialization
	void Start () {
		Input.multiTouchEnabled = true; //允許多點觸控
	}
	
	// Update is called once per frame
	void Update () {
		//判斷平台
		#if !UNITY_EDITOR && ( UNITY_IOS || UNITY_ANDROID )
		
			MobileInput();
		
		#else
		
			DeskopInput();
		
		#endif
	}

	void DeskopInput (){
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(mouseray, out hit))
			{
				if(hit.transform==obj_choose.transform) {
					obj_tran = hit.transform;
				}
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			Ang ();			
			obj_tran = null;
		}
		
		if (obj_tran) Rot();

	}

	void MobileInput(){
		if (Input.touchCount == 1) { //1個手指觸控式螢幕
			if(Input.touches[0].phase == TouchPhase.Began){ //開始觸控
				m_screenpos=Input.touches[0].position; //記錄手指觸控的位置
			}
			if(Input.touches[0].phase == TouchPhase.Ended && Input.touches[0].phase != TouchPhase.Canceled){//手指離開螢幕
				Vector2 pos =Input.touches[0].position;
				
				/*Ray screenray=Camera.main.ScreenPointToRay(pos);
				RaycastHit hit;

				if(Physics.Raycast(screenray,out hit)){
					if(hit.transform == obj_tran.transform){
						obj_tran= hit.transform;
					}
				}*/
			if(Mathf.Abs(m_screenpos.x - pos.x) > Mathf.Abs(m_screenpos.y - pos.y)){//手指水平移動
				
				if(m_screenpos.x > pos.x){ //手指向左滑動
					Ang ();			
					obj_tran = null;
				}
				else{ //手指向右滑動
					Ang ();			
					obj_tran = null;
				}
				if (obj_tran) Rot();
			}
			else{
				if(m_screenpos.y>pos.y){ //手指向下滑動
					
				}
				else{ //手指向上滑動
					
				}
				if (obj_tran) Rot();
			}
			
			}
		}
	}


	void Ang(){
		if (obj_tran.eulerAngles.y > 45 && obj_tran.eulerAngles.y <= 135) {
			float Ry = obj_tran.eulerAngles.y-90;
			if(Ry!=0) obj_tran.Rotate(new Vector3(0,-Ry,0));
		}
		else if(obj_tran.eulerAngles.y> 135 && obj_tran.eulerAngles.y <= 225)
		{
			float Ry = obj_tran.eulerAngles.y-180;
			if(Ry!=0) obj_tran.Rotate(new Vector3(0,-Ry,0));
		}
		else if(obj_tran.eulerAngles.y > 225 && obj_tran.eulerAngles.y <= 315)
		{
			float Ry = obj_tran.eulerAngles.y-270;
			if(Ry!=0) obj_tran.Rotate(new Vector3(0,-Ry,0));
		}
		else if(obj_tran.eulerAngles.y>315 && obj_tran.eulerAngles.y < 360)
		{
			float Ry = obj_tran.eulerAngles.y-360;
			obj_tran.Rotate(new Vector3(0,-Ry,0));
		}
		else if(obj_tran.eulerAngles.y > 0 && obj_tran.eulerAngles.y <= 45)
		{
			float Ry = obj_tran.eulerAngles.y-0;
			obj_tran.Rotate(new Vector3(0,-Ry,0));
		}
	}


	void Rot (){
		Matrix4x4 localmatrix = obj_tran.worldToLocalMatrix;
		
		Vector3 vUp = localmatrix.MultiplyVector(new Vector3(0, 1, 0));
		Vector3 vRight = -localmatrix.MultiplyVector(new Vector3(0, 1, 0));
		
		float fMoveX = -Input.GetAxis("Mouse X") * R_weight ;
		Quaternion rotation = Quaternion.AngleAxis(fMoveX, vUp);
		obj_tran.localRotation *= rotation;
		
		float fMoveY = -Input.GetAxis("Mouse Y") * R_weight;
		Quaternion rotoy = Quaternion.AngleAxis(fMoveY, vRight);
		obj_tran.localRotation *= rotoy;
		
	}
}

