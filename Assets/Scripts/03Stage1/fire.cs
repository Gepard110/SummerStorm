using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {
	// Use this for initialization
	void Start () {
		StartCoroutine("hogehoge");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * 0.05f;
	}

	IEnumerator hogehoge(){
		yield return new WaitForSeconds(2f);
		Destroy(this.gameObject);
	}
}
