using UnityEngine;
using System.Collections;

public class Cam_percent : MonoBehaviour {

	public float baseWidth = 1024;
	public float baseHeight = 600;
	
	private float baseAspect;
	private float targetAspect;
	private float m03; //實際畫面上，GUI的 x 軸起始點為從左邊算來第幾個像素(pixel)
	private float m13; //實際畫面上，GUI的 y 軸起始點為從上方算來第幾個像素(pixel)
	private float m33; //x 軸及 y 軸等比縮放比例的反比
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake(){
		
		float targetWidth = (float)Screen.width;
		float targetHeight = (float)Screen.height;
		
		this.baseAspect = this.baseWidth / this.baseHeight;
		this.targetAspect = targetWidth / targetHeight;
		
		float factor = this.targetAspect > this.baseAspect ? targetHeight / this.baseHeight : targetWidth / this.baseWidth;
		
		this.m33 = 1 / factor;
		this.m03 = (targetWidth - this.baseWidth * factor) / 2 * this.m33;
		this.m13 = (targetHeight - this.baseHeight * factor) / 2 * this.m33;
	}
	
	void OnGUI(){
		
		Matrix4x4 _matrix = GUI.matrix;
		
		_matrix.m33 = this.m33;
		
		if(this.targetAspect > this.baseAspect) _matrix.m03 = this.m03;
		else _matrix.m13 = this.m13;
		
		GUI.matrix = _matrix;
		
		//... Your GUI ...
	}
}
