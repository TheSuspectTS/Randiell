using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="act_",menuName ="Scriptables/Actions")]
public class A_StopDialogue : Action
{
    
    public override void Act(){
        DialogManager.Instance.FinishDialog();
    }
}
