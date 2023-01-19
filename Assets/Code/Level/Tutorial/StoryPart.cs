using System;
using UnityEngine;

[Serializable]
class StoryPart
{
    [field: SerializeField] public float WaitTime { get; private set; } = 2f;
    [field: SerializeField] public WoodPointer Pointer { get; private set; }
}