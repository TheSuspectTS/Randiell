using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="act_",menuName ="Scriptables/Actions/StopDialogue")]
public class A_StopDialogue : Action
{
    
    public override void Act(){
        DialogManager.Instance.FinishDialog();
    }
}
