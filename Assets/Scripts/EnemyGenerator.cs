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

		_enemy.SetActive(true);
		
        return true;
	}
}
