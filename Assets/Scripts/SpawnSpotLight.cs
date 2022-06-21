using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpotLight : MonoBehaviour
{

    public float cadenciafoco = 5;
    private float cadencia;
    public GameObject prefab_spotLight;
    private GameObject instance_spotLight;
    private returntoinit returnComponent;

    public Vector3 initpoint;


    private void Start()
    {

        instance_spotLight = Instantiate(prefab_spotLight, initpoint, prefab_spotLight.transform.rotation);
        returnComponent = instance_spotLight.GetComponent<returntoinit>();
        returnComponent.SetInitPos(initpoint);

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
            if (Physics.Raycast(ray, out RaycastHit hitData))
            {
                instance_spotLight.transform.position = hitData.point;
                returnComponent.Shoot();
            }

            //light.transform.position = initpoint;
            /* Instantiate(lightSpotlogic,spawnpoint,lightSpotlogic.transform.rotation);*/

        }
        else
        {
            cadencia -= Time.deltaTime;
        }
    }
}
