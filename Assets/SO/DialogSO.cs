using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "d_", menuName = "Scriptables/New Dialog")]
public class DialogSO : MonoBehaviour
{
    public NpcInfo npc;
    [TextArea(4,4)] public List<string> dialog_text;
    //Conditions
}
