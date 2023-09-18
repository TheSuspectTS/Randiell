using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityData : MonoBehaviour
{
    // [Header("EnityData")]
    public abstract void Use();
}

public abstract class Entity : EntityData
{
    public abstract override void Use();
} 
