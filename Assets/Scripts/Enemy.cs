using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public int Health = 1;
    private int gamehealth;
    bool hitted = false;

    public Sprite[] enemySprites;
    public Sprite bang;

    float timehitted = 0;



    MovimientoEnemigo MovEnemyComp;
    SpriteRenderer SpriteComponent;


    void EndTimerHitted()
    {
        gameObject.SetActive(false);
      
    }


    void OnHit()
    {
        hitted = true;
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = bang;
        MovEnemyComp.StopMoving();
        managerComponent.addScore(1);
        gamehealth = Health;

    }


    public void OnSpotLight(int _num)
    {
        Health -= _num;

        if (Health <= 0)
        {
            OnHit();
        }

    }


    void OnEnable()
    {
        Random.InitState((int)(Time.timeSinceLevelLoad * 1000f));
        // TODO: I don't like this values 'a pincho'
        float x = Random.Range(9f, 12f);
        float y = Random.Range(-2f, 1f);
        float z = -1f;
        gamehealth = Health;
        gameObject.transform.position = new Vector3(x, y, z);

        if (enemySprites.Length > 0)
        {
            int typeOfEnemy = Random.Range(0, enemySprites.Length);
            MovEnemyComp.enemyType = (EnemyType)typeOfEnemy;
            SpriteComponent.sprite = enemySprites[typeOfEnemy];
        }

    }




    private GameManager managerComponent;

    void Start()
    {
        managerComponent = FindObjectOfType<GameManager>();
        MovEnemyComp = gameObject.AddComponent<MovimientoEnemigo>();
        SpriteComponent = gameObject.GetComponentInChildren<SpriteRenderer>();

    }


    void Update()
    {

        if (hitted)
        {
            timehitted += Time.deltaTime;
            if (timehitted >= 0.3f)
            {
                hitted = false;
                timehitted = 0.0f;
                EndTimerHitted();
            }
        }




    }
}
