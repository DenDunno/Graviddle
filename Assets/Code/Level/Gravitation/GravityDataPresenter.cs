using System.Collections.Generic;
using UnityEngine;


public static class GravityDataPresenter
{
    public static readonly IReadOnlyDictionary<GravityDirection, GravityData> GravityData 
        = new Dictionary<GravityDirection, GravityData>()
    {
        {GravityDirection.Down, new GravityData(new Vector2(0, -1), 0, GravityDirection.Down)},
        {GravityDirection.Right, new GravityData(new Vector2(1,  0), 90, GravityDirection.Right)},
        {GravityDirection.Up, new GravityData(new Vector2(0,  1), 180, GravityDirection.Up)},
        {GravityDirection.Left, new GravityData(new Vector2(-1,  0), 270, GravityDirection.Left)}
    };
}