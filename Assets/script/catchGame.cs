using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchGame : MonoBehaviour
{
    public Camera cam;
    public GameObject bug, playerShooter, bullet;
    public bool canShoot = true;
    private Vector3 mousePos;
    private float heightVal = 3, minWidth = -6f, maxWidth = 6f, coolDown =0.3f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnBug", 3, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //Player controlled ship
        mousePos = Input.mousePosition;
        mousePos.z = transform.position.z - cam.transform.position.z; // calculating z postion
        mousePos.y = transform.position.y - cam.transform.position.y+150; //force y freeze
        playerShooter.transform.position = cam.ScreenToWorldPoint(mousePos);
        

        //Shoot
        
        if (Input.GetMouseButton(0) && canShoot)
        {
            GameObject bulletShoot = Instantiate(bullet, playerShooter.transform.position, transform.rotation);
            Instantiate(bullet, playerShooter.transform.position, transform.rotation);
            Instantiate(bullet, playerShooter.transform.position, transform.rotation);
            Instantiate(bullet, playerShooter.transform.position, transform.rotation);
            canShoot = false;
            StartCoroutine(shootCoolDown(coolDown));
        }
        
        
        

    }

    public void spawnBug()
    {
        Vector3 pos = new Vector3(Random.Range(minWidth, maxWidth), heightVal, 0);
        GameObject buglings = Instantiate(bug, pos, Quaternion.identity);
    }

    private IEnumerator shootCoolDown(float i)
    {
        yield return new WaitForSeconds(i);
        canShoot = true;

    }
    
}
