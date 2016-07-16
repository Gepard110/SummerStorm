using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerCtrl : MonoBehaviour {
	int JoystickMoveRange = 50;
	public int speed;
	Animator anim;
	float angle;
	// Use this for initialization
	void Awake () {
		anim = this.gameObject.GetComponent<Animator> ();
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (CrossPlatformInputManager.GetAxis ("H") == 0 && CrossPlatformInputManager.GetAxis ("V") == 0) {
			anim.SetBool("up",false);
			anim.SetBool("down",false);
			anim.SetBool("left",false);
			anim.SetBool("right",false);
		} else {
			transform.position += new Vector3(CrossPlatformInputManager.GetAxis("H") * speed / JoystickMoveRange, CrossPlatformInputManager.GetAxis("V") * speed/ JoystickMoveRange, 0);
		}
		keyCtrl ();
	}
	public void keyCtrl(){
		if (Input.GetKey ("up")) {
			transform.position += new Vector3(0,0.1f,0);
		}
		if (Input.GetKey ("right")) {
			transform.position += new Vector3(0.1f,0,0);
		}
		if (Input.GetKey ("left")) {
			transform.position += new Vector3(-0.1f,0,0);
		}
		if (Input.GetKey ("down")) {
			transform.position += new Vector3(0,-0.1f,0);
		}
		if (Input.GetKeyUp ("up")) {
			anim.SetBool("up", false);
		}
		if (Input.GetKeyUp ("right")) {
			anim.SetBool("right", false);
		}
		if (Input.GetKeyUp ("left")) {
			anim.SetBool("left", false);
		}
		if (Input.GetKeyUp ("down")) {
			anim.SetBool("down", false);
		}
		if (Input.GetKeyDown ("up")) {
			anim.SetBool("up", true);
		}
		if (Input.GetKeyDown ("right")) {
			anim.SetBool("right", true);
		}
		if (Input.GetKeyDown ("left")) {
			anim.SetBool("left", true);
		}
		if (Input.GetKeyDown ("down")) {
			anim.SetBool("down", true);
		}
	}
}
