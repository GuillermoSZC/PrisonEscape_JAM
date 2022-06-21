using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
	private float speed;
	private int randomMovement;
	private float contador = 0.0f;
	private bool flipFlop = false;

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
		if(randomMovement == 0)
		{
			if (contador == 0.0f)
			{
				flipFlop = true;
			}
			else if (contador == 300.0f)
			{
				flipFlop = false;
			}

			if (flipFlop)
			{
				contador++;
				transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y + Time.deltaTime * speed, transform.position.z);
			}
			else
			{
				contador--;
				transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y - Time.deltaTime * speed, transform.position.z);
			}
		}
		else
		{
			transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
		}
	}

}

