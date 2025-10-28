using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{
    public GameObject miniShooter;
    int buttonClick = 0;
    public bool miniGameButton;
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
        else
        {
            miniShooter.SetActive(false);
        }

    }
    
    public void miniGame() //from the button that starts the mini game
    {
        
        buttonClick++;
        if (buttonClick % 2 == 1)
        {
            miniGameButton = true;
        }
        else
        {
            miniGameButton = false;
        }
        print(buttonClick);

    }
}
