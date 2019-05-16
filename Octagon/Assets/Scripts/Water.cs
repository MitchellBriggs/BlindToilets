using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject LeftTap;
    public GameObject RightTap;
    public GameObject WaterObject;

    // Update is called once per frame
    void Update()
    {
        if (!LeftTap.GetComponent<Rotation>().open || !RightTap.GetComponent<Rotation>().open)
        {
            WaterObject.SetActive(true);
        }
        else
        {
            WaterObject.SetActive(false);
        }
    }
}
