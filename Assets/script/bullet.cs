using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 100;
    public Rigidbody2D bulletRB;
    // Start is called before the first frame update
    void Start()
    {
        
        bulletRB.AddForce(transform.up * speed);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision entered bullet");
        if(collision.collider.tag == "bug")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
