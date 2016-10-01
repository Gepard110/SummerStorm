using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public GameObject EnemyFire;
	public bool canfire = false;
	public float angle;
	public int life = 100;
	Slider slider;
	// Use this for initialization
	void Start ()
	{
		slider = GameObject.Find ("enemy").transform.FindChild("Canvas2").transform.FindChild("Slider").gameObject.GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update (){
		slider.value = life;

		if (life <= 0) {
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Weapon") {
			life -= 20;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			StartCoroutine ("hogehoge");
			this.gameObject.transform.LookAt (other.transform.position);
			transform.Rotate (new Vector3 (0f, 90f, 0f));  
		}
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Player") {
			canfire = true;
			transform.position -= transform.right * 0.025f;
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
		yield return new WaitForSeconds (3);
		if (canfire == true) {
			Instantiate (EnemyFire, this.transform.position, Quaternion.Euler (angle, 270,  0));
			StartCoroutine ("hogehoge");
		}
	}
}
