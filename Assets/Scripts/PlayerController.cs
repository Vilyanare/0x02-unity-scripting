using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed = 2000f;

	private Rigidbody rb;
	private int score = 0;
	public int health = 5;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Pickup") {
			score++;
			Destroy(other.gameObject);
			Debug.Log(string.Format("Score: {0}", score));
		}

		if (other.tag == "Trap") {
			health--;
			Debug.Log(string.Format("Health: {0}", health));
		}

		if (other.tag == "Goal") {
			Debug.Log("You win!");
		}
	}

	void Update () {
		if (health == 0) {
			Debug.Log("Game Over!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)){
			rb.AddForce(speed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)){
			rb.AddForce(-speed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)){
			rb.AddForce(0, 0, speed * Time.deltaTime);
		}

		if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)){
			rb.AddForce(0, 0, -speed * Time.deltaTime);
		}

	}
}
