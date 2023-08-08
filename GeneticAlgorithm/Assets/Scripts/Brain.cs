using System.Collections;
using UnityEngine;

public class Brain
{
    Vector2[] directions;

    public Brain(int size)
    {
        directions = new Vector2[size];
        for(int i = 0; i< size; i++)
        {
            directions[i] = Random.insideUnitCircle;
        }
    }
}