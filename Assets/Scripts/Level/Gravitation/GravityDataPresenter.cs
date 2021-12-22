using System.Collections.Generic;
using UnityEngine;


public class GravityDataPresenter
{
    public static readonly IReadOnlyDictionary<GravityDirection, GravityData> GravityData 
        = new Dictionary<GravityDirection, GravityData>()
    {
        {GravityDirection.Down, new GravityData(new Vector2(0, -1), 0)},
        {GravityDirection.Right, new GravityData(new Vector2(1,  0), 90)},
        {GravityDirection.Up, new GravityData(new Vector2(0,  1), 180)},
        {GravityDirection.Left, new GravityData(new Vector2(-1,  0), 270)}
    };
}