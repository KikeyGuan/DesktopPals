using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Vector3 walkSpot;
    public float coolDown, speed;
    float randX, randY, ranNumTime;
    private IEnumerator coroutine, coroutineDirt;
    public Animator animator;
    public SpriteRenderer sprite;
    public dragable clickBool;
    private bool canDirty=true;

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

        //spaen dirty trasks
        ranNumTime = Random.Range(10f, 15f);
        if (canDirty == true)
        {
            print("coro");
            coroutineDirt = placeDirt(ranNumTime);
            StartCoroutine(coroutineDirt);
            canDirty = false;
        }
        //study this ^^^^ for corotinuewalk puase




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
    private IEnumerator placeDirt(float i)
    {
        
        yield return new WaitForSeconds(i);
        //Instantiate(apple, gameWindow.transform.position, transform.rotation);
        print("SOWAN");
        canDirty = true;
            
    }
    //Need to stop timer, leave "moveTowards" where player drop them off at, then continue timer after some time
    
}
