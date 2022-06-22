using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public int Health = 1;
    private int gamehealth;
    bool hitted = false;
    private bool arrived = false;

    public Sprite[] enemySprites;
    public Sprite bang;

    float timehitted = 0;
    private GameManager managerComponent;

    public AudioSource altavoz;
    public AudioClip[] dieSound;
   // private AudioSource audioComponent;
    private AudioClip Sounddieee; 

    MovimientoEnemigo MovEnemyComp;
    SpriteRenderer SpriteComponent;
    Animator animatorComponent;
    ParticleSystem particleComponent;


    void EndTimerHitted()
    {
        gameObject.SetActive(false);
    }


    void OnHit()
    {
        if (!hitted)
        {
            hitted = true;
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = bang;
            MovEnemyComp.ResetEnemy();
            particleComponent.Stop();
            animatorComponent.enabled = false;
            managerComponent.addScore(1);
//             if(!altavoz.isPlaying)
// 			{
                altavoz.clip = Sounddieee;
                altavoz.Play();
			//}
            //audioComponent.Play();
            gamehealth = Health;
        }
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
            Sounddieee = dieSound[typeOfEnemy];
        }
        hitted = false;
        particleComponent.Play();
        animatorComponent.enabled = true;
        arrived = false;
    }

    private void Awake()
    {
        MovEnemyComp = gameObject.AddComponent<MovimientoEnemigo>();
        SpriteComponent = gameObject.GetComponentInChildren<SpriteRenderer>();
        animatorComponent = gameObject.GetComponent<Animator>();
        particleComponent = gameObject.GetComponentInChildren<ParticleSystem>();
       // audioComponent = gameObject.GetComponent<AudioSource>();
    }



    void Start()
    {
        managerComponent = FindObjectOfType<GameManager>();
    }


    void Update()
    {
		if (managerComponent.GetHealth() <= 0.0f)
		{
			MovEnemyComp.DeactiveBulletEnemy(true);
		}
        else if(managerComponent.paused && managerComponent.GetHealth() > 1.0f)
		{
            MovEnemyComp.DeactiveBulletEnemy(true);
		}
        else if(!managerComponent.paused && managerComponent.GetHealth() > 1.0f)
		{
			MovEnemyComp.DeactiveBulletEnemy(false);
		}

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

        if (!arrived && transform.position.x <= -7.0f)
        {
            managerComponent.damage(1);           
            arrived = true;
        }

        if (transform.position.x <= -10.0f)
        {
            gameObject.SetActive(false);
            MovEnemyComp.ResetEnemy();

        }

        // Update the layer of the enemy
        float maxY = 6f;
        float minY = -4f;
        float dimY = maxY - minY;

        SpriteComponent.sortingOrder = (int)(100f - ((transform.position.y - minY) / dimY) * 100f);
    }
}
