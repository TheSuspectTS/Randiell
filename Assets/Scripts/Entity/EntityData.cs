using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class EntityData : MonoBehaviour
{
    [Header("EnityData")]
    [HideInInspector] public Material _m;
    public DialogManager dm;

    //Temp
    //

    private void Awake() {
        _m = GetComponent<SpriteRenderer>().material;
    }

    private void Start() {
        if(DialogManager.Instance) dm=DialogManager.Instance;
    }

    private void OnMouseEnter() { if(!dm.isTalking){_m.SetFloat("_Scale", 10f);} }
    private void OnMouseExit() { if(!dm.isTalking){_m.SetFloat("_Scale", 0f);} }
    private void OnMouseDown() { if(!dm.isTalking){Use(); _m.SetFloat("_Scale", 0f);} }

    public abstract void Use();
}

public abstract class Entity : EntityData
{
    public abstract override void Use();
} 
