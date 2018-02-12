using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
	
	private Rigidbody rb;
	public float speed;
	public Boundary boundary;
	public float tilt;
	private int count; 
	public Text countText;
	public Text winText;	
	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0; 
		SetCountText ();
		winText.text = "";
	}


	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f,moveVertical);
		rb.velocity = movement * speed;	

		rb.position = new Vector3 
			(
				Mathf.Clamp(rb.position.x, boundary.xMin,  boundary.xMax), 
				0.0f,
				Mathf.Clamp(rb.position.z,  boundary.zMin,  boundary.zMax)
			);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f , rb.velocity.x * -tilt);
	}

		void OnTriggerEnter(Collider other) 
		{	
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1; 
			SetCountText ();

		}
		}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 8) 
		{
			winText.text = " You win!!! ";
		}
	}
}
