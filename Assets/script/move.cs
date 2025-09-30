using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Vector3 walkSpot;
    public float coolDown, speed;
    float randX, randY;
    private IEnumerator coroutine;
    public Animator animator;
    public SpriteRenderer sprite;
    public dragable clickBool;

    void Start()
    {
        //pint(Screen.width);
        //print(Screen.height);

        coroutine = walkCoolDown(coolDown);
        StartCoroutine(coroutine);

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



    }

    void randSpace()
    {
        randX = Random.Range(-8f, 8f);
        randY = Random.Range(-4f, 4f);
    }

    private IEnumerator walkCoolDown(float i)
    {
        while (true)
        {
            yield return new WaitForSeconds(i);
            //print("hello");
            randSpace();
        }

    }
    //Need to stop timer, leave "moveTowards" where player drop them off at, then continue timer after some time
    
}
