using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    [SerializeField] private TMP_Text dialogHistoryField;
    [SerializeField] private GameObject skipArrow;

    [SerializeField] private TMP_Animated _text;
    [SerializeField] private TMP_Text nameField;
    [SerializeField] private Image portraitField;

    public bool isTalking;
    private bool canSkip;

    public int visibleCounter;
    private DialogTree currentTree;
    private Dialog currentDialog;
    [Tooltip("Dialog")]private int dialogIndex;
    [Tooltip("In Dialog Message")]private int dialogMessageIndex;


    [SerializeField] private Transform variantsList;
    [SerializeField] private DialogVariant variantPref;



    private void Awake() { Instance = this; }

    private void Start(){
        _text.onAction.AddListener((action) => SetAction(action));
        FinishDialog();
    }

    public void FinishDialog(){
        //Reset
        portraitField.gameObject.SetActive(false);
        skipArrow.SetActive(false);
        nameField.text = "";
        _text.text = "";
        currentTree = null;
        currentDialog = null;
        isTalking = false;
        canSkip = false;

        dialogHistoryField.text += "\n\n" + "----------------";
    }

    public void Skip(){
        if(!isTalking) return;

        if(!canSkip) { this.SetAction("skip"); return; }

        canSkip = false;


        if(dialogMessageIndex<currentDialog.dialog_text.Count-1) { 
            dialogMessageIndex++;
            ContinueDialogue();
        }
        else if(dialogIndex<currentTree.line.dialogs.Length-1) {
            dialogMessageIndex=0;
            dialogIndex++;
            ContinueDialogue();
        }
        else ShowVariants();
    }

    public void ChooseVariant(DialogTree _variant){
        variantsList.gameObject.SetActive(false);

        TryDialog(_variant);
    }

    private void ShowVariants(){

        if(currentTree.tree.Length == 0){
            FinishDialog();
            return;
        }

        variantsList.gameObject.SetActive(true);

        //Creal list
        foreach(Transform c in variantsList) Destroy(c.gameObject);

        //Get all next dialogs
        List<DialogTree> allowedTrees = new List<DialogTree>();
        for(int i=0;i<currentTree.tree.Length;i++){

            int acceptedConditions = 0;

            //Check for conditions
            if(currentTree.tree[i].conditions.Length == 0){
                allowedTrees.Add(currentTree.tree[i]);
                continue;
            }
            else{
                for(int c=0;c<currentTree.tree[i].conditions.Length;c++){
                    string _condition = currentTree.tree[i].conditions[c];

                    if(_condition == "") acceptedConditions++;
                }
            }

            if(acceptedConditions == currentTree.tree[i].conditions.Length-1) allowedTrees.Add(currentTree.tree[i]);

        }

        for(int i=0;i<allowedTrees.Count;i++){
            Instantiate(variantPref,variantsList).Init(allowedTrees[i]);
            Debug.Log("Variant: " + allowedTrees[i].enterText);

        }
    }

    private void Init(Sprite _portrait, string _name){
        isTalking = true;

        //Reset
        portraitField.sprite = null;
        nameField.text = "";
        
        //Set
        if(_portrait) { portraitField.gameObject.SetActive(true); portraitField.sprite = _portrait; }
        else Debug.LogWarning("No Portrait");

        if(_name.Length>0) nameField.text = _name;
        else Debug.LogWarning("No Name");
    }

    private void ContinueDialogue(){
        TryDialog(null);
    }

    public void TryDialog(DialogTree _tree){
        
        //Init and reset
        if(!isTalking){
            currentTree = _tree;
            dialogIndex = 0;
            dialogMessageIndex = 0;
            canSkip = false;
        }
        visibleCounter = 0;
        skipArrow.SetActive(false);
        NpcInfo _npc = currentTree.line.npc;
        currentDialog = currentTree.line.dialogs[dialogIndex];

        string talkingName = "";
        Sprite talkingPortrait = null;

        //Name, Portrait set
        if(currentDialog.view_name.Length>0) talkingName = currentDialog.view_name;        
        else talkingName = _npc.npc_name;
        
        if(currentDialog.view_protrait) talkingPortrait = currentDialog.view_protrait;
        else talkingPortrait = _npc.portait;
        
        Init(talkingPortrait, talkingName);


        //Display Dialog Text
        string text_to_display = currentDialog.dialog_text[dialogMessageIndex];
        DisplayText(text_to_display);
        if(dialogHistoryField) {
            
            dialogHistoryField.text += "\n\n" + "-" + talkingName + ": " + _text.text;
        }

    }

    public void DisplayText(string _text)
    {
        this._text.ReadText(_text);
    }

    public void SetAction(string action)
    {

        if (action == "shake")
        {
            Debug.Log("Camera Shake!");
            // StartCoroutine(ShakeCam(.1f,.07f));
        }
        else if (action == "skip")
        {
            if(!isTalking) return;
            skipArrow.SetActive(true);
            canSkip = true;
        }
        else
        {
            // PlayParticle(action);
            /*
            if (action == "sparkle")
            {
                dialogueAudio.effectSource.clip = dialogueAudio.sparkleClip;
                dialogueAudio.effectSource.Play();
            }
            else if (action == "rain")
            {
                dialogueAudio.effectSource.clip = dialogueAudio.rainClip;
                dialogueAudio.effectSource.Play();
            }*/
            return;
        }
    }
}
