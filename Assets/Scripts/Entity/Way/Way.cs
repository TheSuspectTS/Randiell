using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : Entity
{
    public DialogTreeSO contextMenu;
    public Room room;

    public override void Use(){

        if(contextMenu){
            DialogManager.Instance.TryDialog(contextMenu.root,null);
        }
        else{
            room.Use(); 
        }

    }

}
