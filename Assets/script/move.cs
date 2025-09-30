using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Vector3 walkSpot;
    private Vector3 mousePosition;
    public float coolDown, speed;
    float randX, randY;
    private IEnumerator coroutineWalkCD, coroutineStayCD;
    public Animator animator;
    public SpriteRenderer sprite;
    public dragable clickBool;
    public Camera cam;

    void Start()
    {
        //pint(Screen.width);
        //print(Screen.height);

        coroutineWalkCD = walkCoolDown(coolDown);
        coroutineStayCD = stayCoolDown(coolDown);
        StartCoroutine(coroutineWalkCD);
        //StartCoroutine(coroutineStayCD);


    }

    // Update is called once per frame
    void Update()
    {
        float walkSpeed = speed * Time.deltaTime;
        walkSpot = new Vector3(randX, randY, 0);
        transform.position = Vector3.MoveTowards(transform.position, walkSpot, walkSpeed);

        //Flip
        if (randX > transform.position.x)
        {
            sprite.flipX = true;
        }
        if (randX < transform.position.x)
        {
            sprite.flipX = false;
        }

        //////////Animator//////////////

        if (transform.position != walkSpot) //walk
        {
            animator.SetBool("mouseClick", false);
            animator.SetBool("isWalk", true);
        }
        if (transform.position == walkSpot) //idle
        {
            animator.SetBool("mouseClick", false);
            animator.SetBool("isWalk", false);
        }
        if (clickBool.clicked == true) //lift
        {
            animator.SetBool("mouseClick", true);
        }





        //testing if start and stop coroutine works
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(coroutineStayCD);
            print("starting up");
        }
        else
        {
            StopCoroutine(coroutineStayCD);
        }
    }

    void randSpace()
    {
        randX = Random.Range(-8f, 8f);
        randY = Random.Range(-4f, 4f);
    }

    private IEnumerator walkCoolDown(float i)
    {
        print("start WALK");
        StopCoroutine(coroutineStayCD);
        while (true)
        {
            yield return new WaitForSeconds(i);
            print("hello");
            randSpace();
        }

    }


    //Need to stop timer, leave "moveTowards" where player drop them off at, then continue timer after some time
    private IEnumerator stayCoolDown(float i)
    {
        print("start STAY");
        //StopCoroutine(coroutineWalkCD);
        //mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        //walkSpot = new Vector3(mousePosition.x, mousePosition.y, 0);
        yield return new WaitForSeconds(i);
        print(i);
        StartCoroutine(coroutineWalkCD);
    }

    void OnMouseUp()
    {
        print("mouse up");
        //StopCoroutine(coroutineWalkCD);
        StartCoroutine(coroutineStayCD);
        
    }


    
}
