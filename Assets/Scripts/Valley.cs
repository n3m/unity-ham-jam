﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valley : MonoBehaviour
{
    public List<Tree> Entities = new List<Tree>();

    public static float[] width = new float[2] { 3, 5 };
    public float actualWidth = 0;
    public Valley(float width)
    {
        this.actualWidth = width;
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
