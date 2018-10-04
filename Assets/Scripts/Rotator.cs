using UnityEngine;

public class Rotator : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		Vector3 rot = transform.rotation.eulerAngles;
		rot.y = rot.y + 45f * Time.deltaTime;
		if (rot.y > 360) {
			rot.y -= 360;
		}

		transform.eulerAngles = rot;
	}
}
