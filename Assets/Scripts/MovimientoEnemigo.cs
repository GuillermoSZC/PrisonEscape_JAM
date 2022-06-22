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


	private float initaccel = 0.01f;
	private float accel = 0.01f;

	private bool zigzagFlipFlop = false;
	private bool thirdFlipFlop = false;
	private bool deactiveBulletEnemy = false;
	
	public EnemyType enemyType = EnemyType.NONE;

	public float speedMultiplier = 1f;

	// Start is called before the first frame update
	void Start()
	{

	}

    private void OnEnable()
    {
		speed = Random.Range(2.0f, 5.0f) * speedMultiplier;
		accel = initaccel * speedMultiplier;
		deactiveBulletEnemy = false;
    }

    // Update is called once per frame
    void Update()
	{
		EnemyMovement();
	}

	public void DeactiveBulletEnemy(bool _validate)
	{
		deactiveBulletEnemy = _validate;
	}

	public void ResetEnemy()
    {
		bulletPrisoner = 0.0f;
		accel = 0.0f;
		speed = 0.0f;
        bulletPrisoner = 0.0f;
        zigzagCont = 0.0f;
        thirdMovement = 0.0f;
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
				Vector3 temp = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y + Time.deltaTime * speed, transform.position.z);

				if (temp.y >= 3.24f)
                {
					temp.y = 3.24f;
                }
				transform.position = temp;
			}
			else
			{
                zigzagCont--;
                Vector3 temp = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y - Time.deltaTime * speed, transform.position.z);
                if (temp.y <= -3.07f)
                {
                    temp.y = -3.07f;
                }
                transform.position = temp;
            }
		}
		else if (enemyType == EnemyType.SKINHEAD)
		{
			if(!deactiveBulletEnemy)
			{
				bulletPrisoner = bulletPrisoner - accel * Time.deltaTime;
				transform.position = new Vector3(transform.position.x + bulletPrisoner, transform.position.y, transform.position.z);
			}
			else
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			}
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
				Vector3 temp = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y + Time.deltaTime * speed, transform.position.z);
                if (temp.y >= 3.24f)
                {
                    temp.y = 3.24f;
                }
                transform.position = temp;
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

