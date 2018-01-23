using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	[SerializeField] private float resetPosition = -21.65f;
	[SerializeField] private float startPosition = 79.67f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {

		if (!GameManager.instance.GameOver) {
			transform.Translate(Vector3.left * ((GameManager.instance.GameSpeed) * Time.deltaTime));

			if (transform.localPosition.x <= resetPosition) {
				Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
				transform.position = newPos;
			}
		}

	}
}
