﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorSingleAxis : MonoBehaviour
{
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 0, 0) * rotationSpeed* Time.deltaTime);
    }
}
