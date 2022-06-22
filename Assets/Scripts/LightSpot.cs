using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpot : MonoBehaviour
{
    // Start is called before the first frame update
    //     void Start()
    //     {
    //         
    //     }
    // 
    //     // Update is called once per frame
    //     void Update()
    //     {
    //         
    //     }


    private void OnTriggerEnter(Collider other)
    {
        Enemy comp = other.GetComponent<Enemy>();
        if (comp)
        {
            comp.OnSpotLight(1);
            GetComponentInChildren<ParticleSystem>().Play();
        }
    }


}
