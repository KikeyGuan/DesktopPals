using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableCreature : MonoBehaviour
{
    public move creatureMovement;
    public Animator creatureAnimator;
    //public Animator creatureStill;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("hit outside");
        if (other.gameObject.tag == "Player")
        {
            print("hit");
            creatureMovement.enabled = false;
            creatureAnimator.SetBool("isWalk", false);
            creatureAnimator.SetBool("mouseClick", false);
            //move game object bun here so you can move boht window and creature
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        print("hit outside");
        if (other.gameObject.tag == "Player")
        {
            print("hit");
            creatureMovement.enabled = true;
            creatureAnimator.SetBool("isWalk", true);
            creatureAnimator.SetBool("mouseClick", true);
        }
    }
}
