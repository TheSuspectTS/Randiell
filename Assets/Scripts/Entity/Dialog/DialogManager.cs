using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private TMP_Animated _text;
    [SerializeField] private TMP_Text nameText;

    //Temp
    private bool isTalking;

    private bool nextMessage;
    private DialogTree currentTree;


    private void Start(){
        _text.onAction.AddListener((action) => SetAction(action));
    }

    public void TryDialog(DialogTree _tree){
        
        if(!isTalking){

            isTalking = true;





        }

    }

    public void StartDialogue(string _text)
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
            // arrow.SetActive(true);
            nextMessage = true;
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
