using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    public dragable drag;
    // Start is called before the first frame update
    void Start()
    {
        drag.cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
}
