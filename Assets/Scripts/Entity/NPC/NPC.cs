using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : Entity
{
    [SerializeField] private NpcInfo info;
    [SerializeField] private DialogTreeSO dialog;

    //Temp
    //

    // private void Start() {
    //     if(DialogManager.Instance) dm=DialogManager.Instance;
    // }

    private void Update() {
        if(dm.isTalking) _m.SetFloat("_Scale", 0f);

    }

    public override void Use(){

        DialogManager.Instance.TryDialog(dialog.root, this);
        
    }

}