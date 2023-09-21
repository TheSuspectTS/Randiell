using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="act_",menuName ="Scriptables/Actions/Quit")]
public class A_Quit : Action
{
    public override void Act(){
        Application.Quit();
    }
}
