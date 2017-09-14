using UnityEngine;
using System.Collections;

public class DS_data : MonoBehaviour {
	public string DSname;
	public string DStag;
	public string right;
	public string left;
	public string up;
	public string down;

	public void SetLeft(string temp){
		left = temp;
	}
	public void SetRight(string temp){
		right = temp;
	}
	public void SetUP(string temp){
		up = temp;
	}
	public void SetDown(string temp){
		down = temp;
	}
	
	public string returnName(){
		return name;
	}
}
