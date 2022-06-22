using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpotLight : MonoBehaviour
{

    public float cadenciafoco = 0.2f;
    private float cadencia;
    public GameObject prefab_spotLight;
    private GameObject instance_spotLight;
    private returntoinit returnComponent;

    Vector3 initpoint = new Vector3(-90,-90,-90);


    private void Start()
    {

        instance_spotLight = Instantiate(prefab_spotLight, initpoint, prefab_spotLight.transform.rotation);
        returnComponent = instance_spotLight.GetComponent<returntoinit>();
        returnComponent.SetInitPos(initpoint);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && cadencia <= 0)
        {
           
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
