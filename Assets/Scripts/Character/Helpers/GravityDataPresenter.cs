using System.Collections.Generic;
using UnityEngine;


public class GravityDataPresenter
{
    public static readonly List<GravityData> GravityData = new List<GravityData>()
    {
        new GravityData(new Vector2(0  , -1) , 0),
        new GravityData(new Vector2(1  ,  0) , 90),
        new GravityData(new Vector2(0  ,  1) , 180),
        new GravityData(new Vector2(-1 ,  0) , 270)
    };
}