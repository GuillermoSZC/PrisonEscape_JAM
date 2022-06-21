using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpotLight : MonoBehaviour
{

    public float cadenciafoco = 5;
    private float cadencia;
    public GameObject lightSpotlogic;
    private GameObject light;
    Vector3 spawnpoint;
    bool canSpawn = true;

    private void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        

        if (/*canSpawn &&*/ Input.GetButton("Fire1") && cadencia <= 0)
        {
         /*   canSpawn = false;*/
            cadencia = cadenciafoco;
            Vector3 screenPos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(screenPos);
            if(Physics.Raycast(ray,out RaycastHit hitData))
            {
               spawnpoint = hitData.point;
            }

            
            Instantiate(lightSpotlogic,spawnpoint,lightSpotlogic.transform.rotation);
            
        }
        else
        {
            cadencia -= Time.deltaTime;
        }
    }
}
