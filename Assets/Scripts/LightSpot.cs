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
      EnemyLife comp = other.GetComponent<EnemyLife>();
        if (comp)
        {
            comp.OnSpotLight(1);
        }
    }


}
