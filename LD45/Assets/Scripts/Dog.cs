﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Parasite
{

    public float Dog_Speed;

    void Start()
    {
        Speed = Dog_Speed;
        RB2D = GetComponent<Rigidbody2D>();
    }

    public override void Especial()
    {
    }
}
