using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{

    public int Health = 1;
    private int gamehealth;
    public Sprite bang;

    private GameManager managerComponent;

   public void OnSpotLight(int _num)
    {
        Health -= _num;

        if (Health <= 0)
        {
            //muerto
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = bang;
            gamehealth = Health;
            managerComponent.addScore(1);
            gameObject.SetActive(false);

        }
        
    }



  


    void Start()
    {
        managerComponent = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        
    }
}
