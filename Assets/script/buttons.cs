using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{
    public GameObject miniShooter, gameWindow, apple, storyWindow;
    int buttonClick = 0;
    public bool miniGameButton, OnStory = false;
    public catchGame canCloseBool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (miniGameButton == true)
        {
            miniShooter.SetActive(true);
        }
        if (canCloseBool.canClose == true)
        {
            miniShooter.SetActive(false);
        }

    }

    public void food()
    {
        if(OnStory == false)
        {
            Instantiate(apple, gameWindow.transform.position, transform.rotation);
        }
        
    }
    
    public void miniGame() //from the button that starts the mini game
    {
        if(OnStory == false)
        {
            buttonClick++;
            if (buttonClick % 2 == 1)
            {
                canCloseBool.canClose = false;
                canCloseBool.startInvoke = true;
                miniGameButton = true;
            }
            else
            {
                miniGameButton = false;
            }
        }
        

    }

    public void chat()
    {
        OnStory = true;
        storyWindow.SetActive(true);
        //Instantiate(storyWindow, gameWindow.transform.position, transform.rotation);
        ///check out button interactble api
    }

}
