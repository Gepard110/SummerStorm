using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UISetPosition : MonoBehaviour {
	RectTransform rec;
	// Use this for initialization
	void Start () {
		rec = this.GetComponent<RectTransform> (); 
		rec.sizeDelta = new Vector2 (Screen.width/6,Screen.width/6);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}