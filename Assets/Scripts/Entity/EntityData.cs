using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class EntityData : MonoBehaviour
{
    [Header("EnityData")]
    private Material _m;

    private void Awake() {
        _m = GetComponent<SpriteRenderer>().material;
    }

    private void OnMouseEnter() { _m.SetFloat("_Scale", 10f); }
    private void OnMouseExit() { _m.SetFloat("_Scale", 0f); }

    public abstract void Use();
}

public abstract class Entity : EntityData
{
    public abstract override void Use();
} 
