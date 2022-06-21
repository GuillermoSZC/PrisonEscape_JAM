using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public float limitRandomSpeed;


    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2.0f, limitRandomSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Move to target
        // transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);


        if(transform.position.x <= -8.3)
		{
			Destroy(gameObject);
		}
	}
}
