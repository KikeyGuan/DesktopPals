using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class storyDialog : MonoBehaviour
{
    public dragable drag;
    public TextMeshProUGUI text;
    public string[] dialog;
    public float textspeed;
    private int index;
    public buttons activeStory;
    // Start is called before the first frame update
    void Start()
    {
        drag.cam = Camera.main;
        text.text = string.Empty;
        startDialog();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(text.text == dialog[index])
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = dialog[index];
                
            }
        }
        
    }

    void startDialog()
    {
        index =0;
        StartCoroutine(typeLine());
    }
    IEnumerator typeLine()
    {
        foreach (char c in dialog[index].ToCharArray())
        {
            text.text +=c;
            yield return new WaitForSeconds(textspeed);
        }
    }

    void nextLine()
    {
        if(index < dialog.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(typeLine());

        }
        else
        {
            index = 0;
            activeStory.OnStory = false;
            gameObject.SetActive(false);
            
        }
    }




    //story dialog script by:BMo https://www.youtube.com/watch?v=8oTYabhj248
}
