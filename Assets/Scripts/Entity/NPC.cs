using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : Entity
{
    [SerializeField] private NpcInfo info;

    private enum NPC_Variant { Talk, Attack, Back, }
    [SerializeField] private NPC_Variant[] variants;

    public override void Use(){
        
        if(variants.Length > 1){
            //ShowContextMenu
        }
        else if(variants.Length == 1)
        {
            Invoke(variants[0].ToString(),0f);
        }

    }

    private void Talk(){
        //StartDialog
    }
    private void Attack(){
        //StartFight
    }
    private void Back(){
        //ExitContextMenu
    }

}