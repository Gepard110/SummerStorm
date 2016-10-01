using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class joystickdirection : MonoBehaviour {
	[SerializeField] float direction;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		direction = CrossPlatformInputManager.GetAxis ("V") / CrossPlatformInputManager.GetAxis ("H");

	if (CrossPlatformInputManager.GetAxis ("H") >= 0) {
			if (direction > 1) {
				transform.Rotate (new Vector3 (0f, 0f, 0f));
			}

			if (direction > 0.5 && direction < 1) {
				transform.Rotate (new Vector3 (0f, 45f, 0f));
			}

			if (direction > -0.5 && direction < 0.5) {
				transform.Rotate (new Vector3 (0f, 90f, 0f));
			}

			if (direction > -1 && direction < -0.5) {
				transform.Rotate (new Vector3 (0f, 135f, 0f));
			}

			if (direction < -1) {
				transform.Rotate (new Vector3 (0f, 180f, 0f));
			}
		}

		if (CrossPlatformInputManager.GetAxis ("H") <= 0) {
			if (direction > 1) {
				transform.Rotate (new Vector3 (0f, 180f, 0f));
			}

			if (direction > 0.5 && direction < 1) {
				transform.Rotate (new Vector3 (0f, 225f, 0f));
			}

			if (direction > -0.5 && direction < 0.5) {
				transform.Rotate (new Vector3 (0f, 270f, 0f));
			}

			if (direction > -1 && direction < -0.5) {
				transform.Rotate (new Vector3 (0f, 315f, 0f));
			}

			if (direction < -1) {
				transform.Rotate (new Vector3 (0f, 135f, 0f));
			}
		}
	}
}
