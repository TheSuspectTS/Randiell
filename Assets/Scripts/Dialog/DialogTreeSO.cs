using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "dt_", menuName = "Scriptables/Dialog/New Tree")]
public class DialogTreeSO : ScriptableObject
{
    // public DialogLine line;
    // public DialogTree[] tree;
    public DialogTree root;
}

[System.Serializable]
public class DialogTree
{
    [Tooltip("What will player say to enter dialog")]public string enterText = "Your Text";
    [Tooltip("Conditions to enable this line")]public string[] conditions;
    [Tooltip("What will happend")]public Action[] actions;
    [Tooltip("Dialog")]public DialogLine line;
    [Tooltip("Next dialogs (Continue)")]public DialogTree[] tree;
}

[System.Serializable]
public class DialogLine
{
    [Tooltip("Not important")] public string lineName = "_-_";
    [Tooltip("With whom player is talking")] public NpcInfo npc;
    public Dialog[] dialogs;
}

[System.Serializable]
public class Dialog
{
    [Tooltip("If null will select npc name")] public string view_name;
    [Tooltip("If null will select npc portait")] public Sprite view_protrait;
    [Tooltip("View text line")] [TextArea(4,4)] public List<string> dialog_text;
    // public Dialog[] con;
}