using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{

    public int Health = 1;

   public void OnSpotLight(int _num)
    {
        Health -= _num;

        if (Health <= 0)
        {
            //muerto
            Destroy(gameObject);
        }
    }






    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
