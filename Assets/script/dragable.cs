using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragable : MonoBehaviour
{
    //public Vector3 mousePosition;
    public Camera cam;
    public bool clicked;
    private bool drag;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (drag == true)
        {
            transform.position = cam.ScreenToWorldPoint(Input.mousePosition) + offset;
        }


    }
    void OnMouseDown()
    {
        drag = true;
        offset = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        //mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        clicked = true;

    }
    void OnMouseUp()
    {
        drag = false;
        clicked = false;
    }
}

//moving sprites at postion clicked: https://www.youtube.com/watch?v=izag_ZHwOtM&ab_channel=Firnox
