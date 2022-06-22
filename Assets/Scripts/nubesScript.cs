using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nubesScript : MonoBehaviour
{
    public float speed = 0;
    Renderer renderer;

    private void Start()
    {
        renderer = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
    }
}
