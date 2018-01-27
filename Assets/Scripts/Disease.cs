﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores information about the disease
/// </summary>
public class Disease {
    public Color color;
    public int deathTime = -1;

    /*public Disease(Color c)
    {
        color = c;
        deathTime = -1;
    }*/

    public Disease(Color c, int d = -1)
    {
        color = c;
        deathTime = d;
    }
}