using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
	private float speed;
	private float randomMovement;

	// Start is called before the first frame update
	void Start()
	{
		speed = Random.Range(2.0f, 9.0f);
	}

	// Update is called once per frame
	void Update()
	{
		// Move to target
		// transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
		randomMovement = Random.Range(0.0f, 10.0f);

		if (randomMovement <= 5.0f)
		{
			transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y + 0.007f, transform.position.z);
		}
		else
		{
			transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y - 0.007f, transform.position.z);
		}


		if (transform.position.x <= -8.3)
		{
			Destroy(gameObject);
		}
	}
}
