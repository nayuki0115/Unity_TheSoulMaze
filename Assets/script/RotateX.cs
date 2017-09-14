using UnityEngine;
using System.Collections;

public class RotateX : MonoBehaviour {
	private Transform hitTransform;
	
	public GameObject ObjCon;
	public float R_weight=5.0f;
	
	void Start () {
		
	}
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(mouseray, out hit))
			{
				if(hit.transform==ObjCon.transform) {
					hitTransform = hit.transform;
				}
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
		
		Vector3 vUp = localmatrix.MultiplyVector(new Vector3(1, 0, 0));
		Vector3 vRight = localmatrix.MultiplyVector(new Vector3(1, 0, 0));
		
		float fMoveX = -Input.GetAxis("Mouse X") * R_weight ;
		Quaternion rotation = Quaternion.AngleAxis(fMoveX, vUp);
		hitTransform.localRotation *= rotation;
		
		float fMoveY = -Input.GetAxis("Mouse Y") * R_weight;
		Quaternion rotoy = Quaternion.AngleAxis(fMoveY, vRight);
		hitTransform.localRotation *= rotoy;
		
	}

	void Ang(){

		if(hitTransform.eulerAngles.x>45 && hitTransform.eulerAngles.x<=90 && hitTransform.eulerAngles.y!=180)
		{
			float Rx = hitTransform.eulerAngles.x-90;
			hitTransform.Rotate(new Vector3(-Rx,0,0));
		}
		else if(hitTransform.eulerAngles.x>=45 && hitTransform.eulerAngles.x<90 && hitTransform.eulerAngles.y==180)
		{
			float Rx = hitTransform.eulerAngles.x-90;
			hitTransform.Rotate(new Vector3(Rx,0,0));
		}
		else if(hitTransform.eulerAngles.x<45 && hitTransform.eulerAngles.x>=0 && hitTransform.eulerAngles.y==180)
		{
			float Rx = hitTransform.eulerAngles.x-0;
			hitTransform.Rotate(new Vector3(Rx,0,0));
		}
		else if(hitTransform.eulerAngles.x>=315 && hitTransform.eulerAngles.x<360 && hitTransform.eulerAngles.y==180)
		{
			float Rx = hitTransform.eulerAngles.x-360;
			hitTransform.Rotate(new Vector3(Rx,0,0));
		}
		else if(hitTransform.eulerAngles.x<315 && hitTransform.eulerAngles.x>270 && hitTransform.eulerAngles.y==180)
		{
			float Rx = hitTransform.eulerAngles.x-270;
			hitTransform.Rotate(new Vector3(Rx,0,0));
		}
		else if(hitTransform.eulerAngles.x>=270 && hitTransform.eulerAngles.x<=315 && hitTransform.eulerAngles.y!=180)
		{
			float Rx = hitTransform.eulerAngles.x-270;
			hitTransform.Rotate(new Vector3(-Rx,0,0));
		}
		else if(hitTransform.eulerAngles.x>315 && hitTransform.eulerAngles.x<360 && hitTransform.eulerAngles.y!=180)
		{
			float Rx = hitTransform.eulerAngles.x-360;
			hitTransform.Rotate(new Vector3(-Rx,0,0));
		}
		else if(hitTransform.eulerAngles.x>=0 && hitTransform.eulerAngles.x<=45 && hitTransform.eulerAngles.y!=180)
		{
			float Rx = hitTransform.eulerAngles.x-0;
			hitTransform.Rotate(new Vector3(-Rx,0,0));
		}
	}
	
}
