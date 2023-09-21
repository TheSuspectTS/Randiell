using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class DialogVariant : MonoBehaviour
{
    [SerializeField] private TMP_Text enterTextField;
    [SerializeField] private DialogTree treeData;
    [SerializeField] private Button button;
    // [SerializeField] private List<Action> _actions = new List<Action>();

    public void Init(DialogTree _tree){
        treeData = _tree;
        enterTextField.text = treeData.enterText;
        
        button.onClick.AddListener(() => Action());

    }

    public void Action(){
        for(int i=0;i<treeData.actions.Length;i++) treeData.actions[i].Act();
    }
}
