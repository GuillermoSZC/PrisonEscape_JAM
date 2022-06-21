using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
	private float speed;
	private int randomMovement;

	private float zigzagCont = 0.0f;
	private float bulletPrisoner = 0.0f;
	private float thirdMovement = 0.0f;

	private bool zigzagFlipFlop = false;
	private bool thirdFlipFlop = false;
	
	public EnemyType enemyType = EnemyType.NONE;

	// Start is called before the first frame update
	void Start()
	{
		speed = Random.Range(2.0f, 9.0f);
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
			thirdMovement = 0.0f;
		}
	}

	private void EnemyMovement()
	{
		if(enemyType == EnemyType.SCARFACE)
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
		else if (enemyType == EnemyType.SKINHEAD)
		{
			bulletPrisoner = bulletPrisoner - 0.002f * Time.deltaTime;
			transform.position = new Vector3(transform.position.x + bulletPrisoner, transform.position.y, transform.position.z);
		}
		else if (enemyType == EnemyType.NORMALMAN)
		{
			if(thirdMovement == 0.0f)
			{
				thirdFlipFlop = true;
			}
			else if(thirdMovement == 1700.0f)
			{
				thirdFlipFlop = false;
				thirdMovement = 0.0f;
			}

			if(thirdFlipFlop && thirdMovement <= 200.0f)
			{
				thirdMovement++;
				transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y + Time.deltaTime * speed, transform.position.z);
			}
			else if(thirdFlipFlop)
			{
				thirdMovement++;
				transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);

			}
		}
		else if (enemyType == EnemyType.OLDMAN)
		{
			transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
		}
	}

}

