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
    public float initialDelay = 2f; // 1 enemy per initialDelay seconds
    [Tooltip("Minimum delay to spawn enemies")]
    public float minDelay = 0.5f;

    private float timeToSpawnEnemy = 0f;
    private GameManager managerComponent;
    public float delay = 0f;
    public int relativeScore = 0;

    public AudioSource altavozenemy;

    void Start()
    {
        delay = initialDelay;
        timeToSpawnEnemy = initialDelay;
        managerComponent = FindObjectOfType<GameManager>();
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
                    CreateEnemy(enemy, altavozenemy);
                    enemy.GetComponent<MovimientoEnemigo>().speedMultiplier = Mathf.Min(2f, enemy.GetComponent<MovimientoEnemigo>().speedMultiplier + 0.1f);
                    if (delay > minDelay)
					{
                        delay =  Mathf.Max(minDelay, initialDelay - managerComponent.GetScore() * 0.1f); // Substract 0.1 per enemy killed
					}
                    timeToSpawnEnemy = delay;
				}
			}
		}
    }

    bool CreateEnemy(GameObject _enemy, AudioSource _altavoz)
	{
        _enemy.GetComponent<Enemy>().altavoz = _altavoz;
		_enemy.SetActive(true);
		
        return true;
	}
}
