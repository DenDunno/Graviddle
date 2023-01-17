using System;

public interface ISwitcher
{
    event Action<bool> Toggled;
}