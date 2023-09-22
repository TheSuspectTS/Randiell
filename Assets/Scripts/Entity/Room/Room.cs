using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : Entity
{
    public A_Move act;

    public override void Use(){
        act.Act(this);

    }

}
