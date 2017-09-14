using UnityEngine;
using System.Collections;

public class RotateZ : MonoBehaviour {
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
		
		Vector3 vUp = localmatrix.MultiplyVector(new Vector3(0, 0, 1));
		Vector3 vRight = -localmatrix.MultiplyVector(new Vector3(0, 0, 1));
		
		float fMoveX = -Input.GetAxis("Mouse X")*R_weight ;
		Quaternion rotation = Quaternion.AngleAxis(fMoveX, vUp);
		hitTransform.localRotation *= rotation;
		
		float fMoveY = -Input.GetAxis("Mouse Y") * R_weight;
		Quaternion rotoy = Quaternion.AngleAxis(fMoveY, vRight);
		hitTransform.localRotation *= rotoy;
		
	}
	
	void Ang(){
		
		if(hitTransform.eulerAngles.z>45 && hitTransform.eulerAngles.z<=135)
		{
			float Rz = hitTransform.eulerAngles.z-90;
			if(Rz != 0)	hitTransform.Rotate(new Vector3(0,0,-Rz));
		}
		else if(hitTransform.eulerAngles.z>135 && hitTransform.eulerAngles.z<=225)
		{
			float Rz = hitTransform.eulerAngles.z-180;
			if(Rz != 0)	hitTransform.Rotate(new Vector3(0,0,-Rz));
		}
		else if(hitTransform.eulerAngles.z>225 && hitTransform.eulerAngles.z<=315)
		{
			float Rz = hitTransform.eulerAngles.z-270;
			if(Rz != 0)	hitTransform.Rotate(new Vector3(0,0,-Rz));
		}
		else if(hitTransform.eulerAngles.z>315 && hitTransform.eulerAngles.z<360)
		{
			float Rz = hitTransform.eulerAngles.z-360;
			hitTransform.Rotate(new Vector3(0,0,-Rz));
		}
		else if(hitTransform.eulerAngles.z>0 && hitTransform.eulerAngles.z<=45)
		{
			float Rz = hitTransform.eulerAngles.z-0;
			hitTransform.Rotate(new Vector3(0,0,-Rz));
		}
	}
	
}
