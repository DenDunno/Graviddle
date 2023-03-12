using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class BoxGravitySelection : IInitializable
{
    [SerializeField] private Image _top;
    [SerializeField] private Image _left;
    [SerializeField] private Image _right;
    [SerializeField] private AudioSource _switchSound;
    private Dictionary<GravityDirection, Image> _images;
    private GravityDirection _current;

    void IInitializable.Initialize()
    {
        _images = new Dictionary<GravityDirection, Image>()
        {
            {GravityDirection.Left, _left},
            {GravityDirection.Right, _right},
            {GravityDirection.Up, _top},
        };
    }

    public void TrySelectDirection(GravityDirection current, GravityDirection globalDirectionTarget)
    {
        GravityDirection localDirection = GetLocalDirection(current, globalDirectionTarget);
        
        if (IsValid(localDirection))
        {
            SelectDirection(localDirection);
        }       
    }

    private GravityDirection GetLocalDirection(GravityDirection current, GravityDirection globalDirectionTarget)
    {
        int start = (int)current;
        int target = (int)globalDirectionTarget;
        int result = target - start;

        if (result < 0)
        {
            result = 4 + result;
        }

        return (GravityDirection)result;
    }

    private bool IsValid(GravityDirection newDirection)
    {
        return newDirection != GravityDirection.Down &&
               newDirection != _current;
    }

    private void SelectDirection(GravityDirection localDirection)
    {
        DeselectAll();
        _current = localDirection;            
        _images[localDirection].color = Color.green;
        _switchSound.Play();
    }

    public void DeselectAll()
    {
        foreach (Image image in _images.Values)    
        {
            image.color = Color.white;
        }
        
        _current = GravityDirection.Down;
    }
}