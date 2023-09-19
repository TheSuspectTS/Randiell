using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "dt_", menuName = "Scriptables/Dialog/New Tree")]
public class DialogTreeSO : ScriptableObject
{
    public DialogTree root;
}

[System.Serializable]
public class DialogTree
{
    public string enterText = "Your Text";
    public string[] conditions;
    public DialogLine line;
    public DialogTree[] tree;
}

[System.Serializable]
public class DialogLine
{
    public string lineName = "_-_";
    public Dialog[] dialogs;
}

[System.Serializable]
public class Dialog
{
    public NpcInfo npc;
    [TextArea(4,4)] public List<string> dialog_text;
    // public Dialog[] con;
}