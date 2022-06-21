using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returntoinit : MonoBehaviour
{

    private Vector3 initPos;
    private float delta;
    bool setted = false;

    public void SetInitPos(Vector3 _pos)
    {
        initPos = _pos;
    }

    public void Shoot()
    {
        setted = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(setted==true)
        {
            if (delta >= 0.2f)
            {
                setted = false;
                gameObject.transform.position = initPos;
                delta = 0;
            }
            else
            {
                delta += Time.deltaTime;
            }
        }
    }
}
