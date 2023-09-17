using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class OST_Manager : MonoBehaviour
{
    [SerializeField] private AudioClip[] ost;
    [SerializeField] private float nextOstOffset = 1f;
    private AudioSource source;
    private int ostIndex;
    private bool repeatMode;

    [SerializeField] private float scrollSpeed = 100f;
    private Vector2 textStartPos;
    private Vector2 boundaryTextEnd;

    [SerializeField] private RectTransform scrollingText;


    private void Awake() {
        source = GetComponent<AudioSource>();
        ostIndex = Random.Range(0, ost.Length);
        PlayOst(ost[ostIndex]);
        textStartPos = scrollingText.localPosition;
        boundaryTextEnd = -textStartPos;
    }

    private void Update() {

        if(Input.GetKeyDown(KeyCode.T)) source.time = ost[ostIndex].length - 1;

        if(source.time >= ost[ostIndex].length + nextOstOffset){
            if(repeatMode){
                PlayOst(ost[ostIndex]);
            }
            else SkipOst();
        }

        scrollingText.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        if(scrollingText.localPosition.x <= boundaryTextEnd.x) scrollingText.localPosition = textStartPos;
    }

    public void RepeatMode(bool val){
        repeatMode=val;
    }

    public void SkipOst(){
        ostIndex++; 
        if(ostIndex > ost.Length-1) ostIndex = 0;
        scrollingText.localPosition = textStartPos;
        PlayOst(ost[ostIndex]);
    }

    private void PlayOst(AudioClip _clip)
    {
        scrollingText.GetComponent<TMP_Text>().text = ost[ostIndex].name;
        source.clip = _clip;
        source.Play();
    }

}
