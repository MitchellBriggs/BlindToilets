using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DisplayText : MonoBehaviour
{
    public string NewText;
    public Text TextBox;
    private bool hovering;
    private DateTime start;
    private DateTime end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hovering)
        {
            if (DateTime.Compare(DateTime.Now, start.AddMilliseconds(1500)) > 0)
            {
                TextBox.text = NewText;
                TextBox.enabled = true;
            }
        }
    }
    public void OnEnter()
    {
        start = DateTime.Now;
        hovering = true;
    }
    public void OnExit()
    {
        hovering = false;
        TextBox.enabled = false;
    }
}
