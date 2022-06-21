using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float Delay = 1f;
    private float timeToSpawnEnemy = 0f;

    void Start()
    {
        timeToSpawnEnemy = Delay;
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
                    timeToSpawnEnemy = Delay;
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
