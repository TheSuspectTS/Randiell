using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : Entity
{
    [SerializeField] private NpcInfo info;
    [SerializeField] private DialogTreeSO dialog;

    private enum NPC_Variant { Talk, Attack, Back, }
    [SerializeField] private NPC_Variant[] variants;

    //Temp
    public bool firstDialog;
    //

    private void Start() {
        if(DialogManager.Instance) dm=DialogManager.Instance;
        if(firstDialog) Invoke(nameof(FirstD),0.1f);
    }

    private void FirstD(){
        dm.TryDialog(dialog.root);
    }

    private void Update() {
        if(dm.isTalking) _m.SetFloat("_Scale", 0f);

    }

    public override void Use(){
        
        // if(variants.Length > 1){
        //     //ShowContextMenu
        // }
        // else if(variants.Length == 1)
        // {
        //     Invoke(variants[0].ToString(),0f);
        // }

        Talk();

    }

    private void Talk(){
        //StartDialog
        DialogManager.Instance.TryDialog(dialog.root);
    }
    private void Attack(){
        //StartFight
    }
    private void Back(){
        //ExitContextMenu
    }

}