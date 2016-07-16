using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UISetPosition : MonoBehaviour {
	RectTransform rec;
	// Use this for initialization
	void Start () {
		rec = this.GetComponent<RectTransform> ();
		rec.sizeDelta = new Vector2 (Screen.height/8,Screen.height/8);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}