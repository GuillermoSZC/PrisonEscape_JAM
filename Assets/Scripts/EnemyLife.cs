using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{

    public int Health = 1;
    private int gamehealth;
    public Sprite bang;
    float time=0;
    bool hitted = false;

    private GameManager managerComponent;



    void OnHit()
    {
        hitted = true;
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = bang;
        managerComponent.addScore(1);
        gamehealth = Health;

    }


    void EndTimer()
    {
        gameObject.SetActive(false);
    }


    public void OnSpotLight(int _num)
    {
        Health -= _num;

        if (Health <= 0)
        {
            OnHit();
            //muerto
           

        }
        
    }



  


    void Start()
    {
        managerComponent = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        if(hitted)
        {
            time += Time.deltaTime;
            if(time>= 0.3f)
            {
                hitted = false;
                time = 0.0f;
                EndTimer();
            }
        }
    }
}
