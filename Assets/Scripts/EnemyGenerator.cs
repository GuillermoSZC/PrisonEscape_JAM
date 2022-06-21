using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Tooltip("Initial delay between the spawns of the enemies")]
    public float delay = 3f; // 1 enemy per initialDelay seconds
    [Tooltip("Minimum delay to spawn enemies")]
    public float minDelay = 0.5f;

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
                        delay -= Time.deltaTime * 0.001f; // To make 
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
		_enemy.SetActive(true);
		
        return true;
	}
}
