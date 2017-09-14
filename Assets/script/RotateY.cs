using UnityEngine;
using System.Collections;

public class RotateY : MonoBehaviour {
	private Transform hitTransform;

	public RaycastHit hit;
	public GameObject ObjCon;
	public float R_weight=5.0f;
	public GameObject I;
	public GameObject II;
	public GameObject III;
	public GameObject IV;
	public int flag=1;

	
	void Start () {
		
	}
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			//RaycastHit hit;
			Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(mouseray, out hit))
			{
				if(hit.transform==ObjCon.transform) {
					hitTransform = hit.transform;
				}
				turn_scenes ();
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			Ang ();			
			hitTransform = null;
		}
		if (hitTransform) Rot();


	}
	void Rot (){
		Matrix4x4 localmatrix = hitTransform.worldToLocalMatrix;

		Vector3 vUp = localmatrix.MultiplyVector(new Vector3(0, 1, 0));
		Vector3 vRight = -localmatrix.MultiplyVector(new Vector3(0, 1, 0));

		float fMoveX = -Input.GetAxis("Mouse X") * R_weight ;
		Quaternion rotation = Quaternion.AngleAxis(fMoveX, vUp);
		hitTransform.localRotation *= rotation;
		
		float fMoveY = -Input.GetAxis("Mouse Y") * R_weight;
		Quaternion rotoy = Quaternion.AngleAxis(fMoveY, vRight);
		hitTransform.localRotation *= rotoy;

	}
	
	void Ang(){
		
		if(hitTransform.eulerAngles.y>45 && hitTransform.eulerAngles.y<=135) //Angle=45~90~135
		{
			float Ry = hitTransform.eulerAngles.y-90;
			if(Ry!=0) hitTransform.Rotate(new Vector3(0,-Ry,0));
		}
		else if(hitTransform.eulerAngles.y>135 && hitTransform.eulerAngles.y<=225)
		{
			float Ry = hitTransform.eulerAngles.y-180;
			if(Ry!=0) hitTransform.Rotate(new Vector3(0,-Ry,0));
		}
		else if(hitTransform.eulerAngles.y>225 && hitTransform.eulerAngles.y<=315)
		{
			float Ry = hitTransform.eulerAngles.y-270;
			if(Ry!=0) hitTransform.Rotate(new Vector3(0,-Ry,0));
		}
		else if(hitTransform.eulerAngles.y>315 && hitTransform.eulerAngles.y<360)
		{
			float Ry = hitTransform.eulerAngles.y-360;
			hitTransform.Rotate(new Vector3(0,-Ry,0));
		}
		else if(hitTransform.eulerAngles.y>0 && hitTransform.eulerAngles.y<=45)
		{
			float Ry = hitTransform.eulerAngles.y-0;
			hitTransform.Rotate(new Vector3(0,-Ry,0));

		}
	}



	void turn_scenes(){

		if (ObjCon.transform.eulerAngles.y == 0) {
						flag = 1;
				}
		if (ObjCon.transform.eulerAngles.y == 90) {
						flag = 2;
				}
		if (ObjCon.transform.eulerAngles.y == 180) {
						flag = 3;
				}
		if (ObjCon.transform.eulerAngles.y == 270) {
						flag = 4;
				}
	

			if(hit.collider.gameObject == I){
					Debug.Log("in");
					Application.LoadLevel (1);
				}
			if(hit.collider.gameObject == II){
					Application.LoadLevel (2);
				}
			if(hit.collider.gameObject == III){
					Application.LoadLevel (3);
				}
			if(hit.collider.gameObject == IV){
					Application.LoadLevel (4);
				}

		}

}
