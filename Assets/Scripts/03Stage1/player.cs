using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour {
	public float lifepoint = 100;
	Slider hpslider;
	Slider btslider;
	public bool temperature = true;
	public bool canthrow = false;
	public int throwthing;
	public GameObject[] throwthings = new GameObject[3];
	public GameObject instantiatepos;
	// Use this for initialization
	void Start () {
		hpslider = GameObject.Find ("Canvas").transform.FindChild("HPSlider").gameObject.GetComponent<Slider> ();
		btslider = GameObject.Find ("Canvas").transform.FindChild("BTSlider").gameObject.GetComponent<Slider> ();
	}

	// Update is called once per frame
	void Update () {
		hpslider.value = lifepoint;

	if (lifepoint > 100) {
			lifepoint = 100;
		}

	if (lifepoint <= 0) {
			Application.LoadLevel(0);
		}

	if (temperature == true) {
			btslider.value += 0.025f;
		} else {
			btslider.value -= 0.025f;
		}

	if (btslider.value >= 50 || btslider.value <= 30 ) {
			lifepoint -= 0.03f;
		}

	if (canthrow == true) {
			if(Input.GetKeyUp("space")){
				Instantiate(throwthings[throwthing],this.transform.position,instantiatepos.gameObject.transform.rotation);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		int damage = Random.Range (0, 5);
		if (other.gameObject.CompareTag ("Enemy")) {
			lifepoint -= damage;
		}

		if (other.gameObject.CompareTag ("ice")) {
			btslider.value -= 19;
		}

		if (other.gameObject.CompareTag ("heal")) {
			lifepoint += 20;
		}
	}

}
