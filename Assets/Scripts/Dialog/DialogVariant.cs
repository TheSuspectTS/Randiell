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
        // for(int i=0;i<treeData.actions.Length;i++) {
        //     // var targetinfo = UnityEvent.GetValidMethodInfo(treeData.actions[i], "Act", new Type[] { typeof(Action) });
        //     // UnityAction<GameObject> action = Delegate.CreateDelegate(typeof(UnityAction<GameObject>), myScriptInstance, targetinfo, false) as UnityAction<GameObject>;
        //     // UnityEventTools.AddObjectPersistentListener<GameObject>(button.onClick, action);

        //     // button.onClick.AddListener(() => Action(treeData.actions[i]));
        //     // button.onClick.AddListener(() => Action());
        //     _actions.Add(_tree.actions[i]);
        // }

        // for(int i=0;i<_actions.Count;i++){
        //     button.onClick.AddListener(() => _actions[i].Act());
        // }
    }

    // public void Action(){
    //     Debug.Log("Action!");
    //     // _a.Act();
    // }
}
