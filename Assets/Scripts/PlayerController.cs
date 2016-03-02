using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour {

	private int count;
	public Text countText;
	public Text WinText;
	public Text TimeText;
	public float speed;
	private Rigidbody rb;
	public float time;



	private bool gameOver;
	private bool restart;

	void Start() {
		
		rb = GetComponent<Rigidbody>();

		count = 0;
		gameOver = false;
		restart = false;


		WinText.text = "";
		TimeText.text = "Time: " + time;
		setCountText ();

	}


	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
		if (time > 0) {
			time -= Time.deltaTime;
			TimeText.text = "Time: " + (int)time;
		}
		if (time <= 1) {
			GameOver ();
		}



	}



	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive(false);
			count = count + 1;
			if (count == 10) {
				GameOver ();
				FixedUpdate ();
			}
			setCountText();
		}

		if(other.gameObject.CompareTag("Red")){
			GameOver ();
			FixedUpdate ();
		}

	}

	void setCountText() {
		countText.text = "Score: "+ count.ToString();

	}

	public void GameOver() {
		rb.gameObject.SetActive(false);
		if (count >= 10) {
			WinText.text = "YOU WIN!!!";
		} else {
			WinText.text = "GAME OVER";
		}
		gameOver = true;
	}
}
