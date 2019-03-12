﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public int pickups;
    public GameObject pickup;
    const float borderMax = 9.5f;

    // Start is called before the first frame update
    public void StartUp()
    {
        pickups = Random.Range(6, 12);
        for (int i = 0; i < pickups; i++)
        {
            Instantiate(pickup, new Vector3(Random.Range(-borderMax, borderMax), 0.5f, Random.Range(-borderMax, borderMax)), transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
