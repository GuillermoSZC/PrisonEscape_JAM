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
    private AudioSource audioSourceComponent;
    private GameManager managerComponent;

    Vector3 initpoint = new Vector3(-90,-90,-90);


    private void Start()
    {

        instance_spotLight = Instantiate(prefab_spotLight, initpoint, prefab_spotLight.transform.rotation);
        returnComponent = instance_spotLight.GetComponent<returntoinit>();
        returnComponent.SetInitPos(initpoint);
        audioSourceComponent = instance_spotLight.GetComponent<AudioSource>();
        managerComponent = GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!managerComponent.GetPaused() && Input.GetButton("Fire1") && cadencia <= 0)
        {
           
            cadencia = cadenciafoco;
            Vector3 screenPos = Input.mousePosition;
            screenPos.x += 32.5f;
            screenPos.y -= 32.0f;
            Ray ray = Camera.main.ScreenPointToRay(screenPos);
            if (Physics.Raycast(ray, out RaycastHit hitData))
            {
                instance_spotLight.transform.position = hitData.point;
                returnComponent.Shoot();
                audioSourceComponent.Play();              
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
