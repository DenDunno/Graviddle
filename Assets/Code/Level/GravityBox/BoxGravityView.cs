using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class BoxGravityView : IInitializable
{
    [SerializeField] private Image _top;
    [SerializeField] private Image _left;
    [SerializeField] private Image _right;
    private Dictionary<GravityDirection, Image> _images;
    
    void IInitializable.Initialize()
    {
        _images = new Dictionary<GravityDirection, Image>()
        {
            {GravityDirection.Left, _left},
            {GravityDirection.Right, _right},
            {GravityDirection.Up, _top},
        };
    }

    public void SelectDirection(GravityDirection direction)
    {
        if (direction != GravityDirection.Down)
        {            
            _images[direction].color = Color.green;
        }       
    }

    public void DeselectAll()
    {
        foreach (Image image in _images.Values)    
        {
            image.color = Color.white;
        }
    }
}