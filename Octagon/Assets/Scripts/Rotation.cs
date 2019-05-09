using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private DateTime lastOpen;
    private bool open;
    private bool hovering;
    private bool opening;
    private bool closing;
    private int count;
    public int RotateTimes;

    // Start is called before the first frame update
    void Start()
    {
        open = true;
        hovering = false;
        opening = false;
        closing = false;
        count = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (GvrControllerInput.AppButton && hovering)
        {
            if (lastOpen == null)
            {
                Open();
            }
            else if (DateTime.Compare(DateTime.Now, lastOpen.AddMilliseconds(200)) > 0)
            {
                Open();
            }
        }
        if (opening && !closing)
        {
            if (count >= RotateTimes)
            {
                count = 0;
                opening = false;
            }
            else
            {
                transform.Rotate(Vector3.up, 10f);
                count++;
            }
        }
        if (closing && !opening)
        {
            if (count >= RotateTimes)
            {
                count = 0;
                closing = false;
            }
            else
            {
                transform.Rotate(Vector3.up, -10f);
                count++;
            }
        }
    }

    private void Open()
    {
        if (open)
        {
            opening = true;
        }
        else
        {
            closing = true;
        }
        open = !open;
        lastOpen = DateTime.Now;
    }
        
    public void OnEnter()
    {
        hovering = true;
    }
    public void OnExit()
    {
        hovering = false;
    }
}
