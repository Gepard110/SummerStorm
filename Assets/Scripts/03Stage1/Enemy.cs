using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public GameObject EnemyFire;
	public bool canfire = false;
	 public float angle;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			//transform.LookAt(other.transform);
			StartCoroutine ("hogehoge");
			this.gameObject.transform.LookAt (other.transform.position);
			transform.Rotate (new Vector3 (0f, 90f, 0f));  
		}
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Player") {
			canfire = true;
			transform.position -= transform.right * 0.05f;
			Vector3 distance = other.gameObject.transform.position-this.transform.position;
			float value = distance.y / distance.x ;
			float theta = Mathf.Atan(value);
			if(this.transform.position.x > other.gameObject.transform.position.x){
				angle = theta * Mathf.Rad2Deg;
			}else{
				angle = 180 + theta * Mathf.Rad2Deg;
			}
		}
	}

	void OnTriggerExit2D (Collider2D other){
		canfire = false;
	}

	IEnumerator hogehoge ()
	{
		yield return new WaitForSeconds (1);
		if (canfire == true) {
			Instantiate (EnemyFire, this.transform.position, Quaternion.Euler (angle, 270,  0));
			StartCoroutine ("hogehoge");
		}
	}
}
