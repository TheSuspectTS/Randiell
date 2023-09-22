using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;

    public Transform roomParent;

    private Room room;

    private void Awake() {
        Instance = this;
    }

    public void ChangeRoom(Room _r){
        room = _r;
        FadeManager.Instance.anim.SetTrigger("Fade");
        Invoke(nameof(Do),.3f);

    }

    private void Do(){
        Destroy(roomParent.GetChild(0).gameObject);
        Instantiate(room,roomParent);
    }
}
