using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
	private float speed;
	private int randomMovement;
	private float zigzagCont = 0.0f;
	private bool zigzagFlipFlop = false;
	private float bulletPrisoner = 0.0f;

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
			gameObject.SetActive(false);
			bulletPrisoner = 0.0f;
			zigzagCont = 0.0f;
		}
	}

	private void EnemyMovement()
	{
		if (randomMovement == 0)
		{
			if (zigzagCont == 0.0f)
			{
				zigzagFlipFlop = true;
			}
			else if (zigzagCont == 300.0f)
			{
				zigzagFlipFlop = false;
			}

			if (zigzagFlipFlop)
			{
				zigzagCont++;
				transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y + Time.deltaTime * speed, transform.position.z);
			}
			else
			{
				zigzagCont--;
				transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y - Time.deltaTime * speed, transform.position.z);
			}
		}
		else if (randomMovement == 1)
		{
			bulletPrisoner = bulletPrisoner - 0.01f * Time.deltaTime;
			transform.position = new Vector3(transform.position.x + bulletPrisoner, transform.position.y, transform.position.z);
		}
		else
		{
			transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
		}
	}

}

