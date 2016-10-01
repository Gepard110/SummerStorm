using UnityEngine;
using System.Collections;

public class rock : MonoBehaviour {
	public player _player;
	// Use this for initialization
	void Start () {
		_player = GameObject.Find("player").gameObject.GetComponent<player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_player.canthrow == true) {
			transform.position += transform.up;
			StartCoroutine ("hogehoge");
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if(_player.canthrow == false){
			_player.canthrow = true;
			_player.throwthing = 0;
			Destroy(this.gameObject);
			}
		}
	}

	IEnumerator hogehoge(){
		yield return new WaitForSeconds(3);
		Destroy (this.gameObject);
	}
}
