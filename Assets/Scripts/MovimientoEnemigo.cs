using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
	private float speed;
	private int randomMovement;
	private float borrachoCont = 0.0f;
	private bool borrachoFlipFlop = false;
	private float zigZagCont = 0.0f;
	private bool zigZagFlipFlop = false;

	// Start is called before the first frame update
	void Start()
	{
		speed = Random.Range(2.0f, 9.0f);
		randomMovement = Random.Range(0, 3);
	}

	// Update is called once per frame
	void Update()
	{
		EnemyMovement();


		if (transform.position.x <= -10.0)
		{
			Destroy(gameObject);
		}
	}

	private void EnemyMovement()
	{
		if (randomMovement == 0)
		{
			if (borrachoCont == 0.0f)
			{
				borrachoFlipFlop = true;
			}
			else if (borrachoCont == 300.0f)
			{
				borrachoFlipFlop = false;
			}

			if (borrachoFlipFlop)
			{
				borrachoCont++;
				transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y + Time.deltaTime * speed, transform.position.z);
			}
			else
			{
				borrachoCont--;
				transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y - Time.deltaTime * speed, transform.position.z);
			}
		}
		else if (randomMovement == 1)
		{
			if (zigZagCont == 0.0f)
			{
				zigZagFlipFlop = true;
			}
			else if (zigZagCont == 50.0f)
			{
				zigZagCont = 0.0f;
				zigZagFlipFlop = false;
			}

			if (borrachoFlipFlop)
			{
				zigZagCont++;
				transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
			}
			else
			{
				transform.position = new Vector3(transform.position.x + 3.0f, transform.position.y, transform.position.z);
			}

		}
		else
		{
			transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
		}
	}

}

