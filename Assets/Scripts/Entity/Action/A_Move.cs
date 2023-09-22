using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="act_",menuName ="Scriptables/Actions/Move")]
public class A_Move : Action
{
    public Room room;

    public override void Act(Entity _e){
        //Move
        Debug.Log("Move!");

        RoomManager.Instance.ChangeRoom(_e.GetComponent<Room>());
    }
}
