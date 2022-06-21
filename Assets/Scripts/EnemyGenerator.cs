using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum EnemyType
{
	NONE = -1,
	OLDMAN,
	NORMALMAN,
	SKINHEAD,
	SCARFACE
}

public class EnemyGenerator : MonoBehaviour
{
    [Tooltip("Initial delay between the spawns of the enemies")]
    public float delay = 3f; // 1 enemy per initialDelay seconds
    [Tooltip("Minimum delay to spawn enemies")]
    public float minDelay = 0.5f;
	public Sprite[] enemySprites;

    private float timeToSpawnEnemy = 0f;

    void Start()
    {
        timeToSpawnEnemy = delay;
    }

    void Update()
    {
        if (ObjectPooler.objectPooler != null)
		{
            timeToSpawnEnemy -= Time.deltaTime;
            if (timeToSpawnEnemy <= 0)
			{
                GameObject enemy = ObjectPooler.objectPooler.GetPooledObject();
                if (enemy != null)
				{
                    CreateEnemy(enemy);
                    if (delay > minDelay)
					{
                        delay -= 0.1f;
					}
                    timeToSpawnEnemy = delay;
				}
			}
		}
    }

    bool CreateEnemy(GameObject _enemy)
	{
        Random.InitState((int)(Time.timeSinceLevelLoad * 1000f));
        // TODO: I don't like this values 'a pincho'
        float x = Random.Range(9f, 12f);
        float y = Random.Range(-2f, 1f);
        float z = -1f;
        _enemy.transform.position = new Vector3(x, y, z);

        if (enemySprites.Length > 0)
		{
            int typeOfEnemy = Random.Range(0, enemySprites.Length);
            _enemy.GetComponent<MovimientoEnemigo>().enemyType = (EnemyType)typeOfEnemy;
            _enemy.GetComponentInChildren<SpriteRenderer>().sprite = enemySprites[typeOfEnemy];
		}

		_enemy.SetActive(true);
		
        return true;
	}
}
