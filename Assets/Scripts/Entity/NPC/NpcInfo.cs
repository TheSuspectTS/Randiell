using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "npc_", menuName = "Scriptables/NPC/New NPC")]
public class NpcInfo : ScriptableObject
{
    [Header("NpcInfo")]
    public string npc_name;
    public Sprite portait;
}
