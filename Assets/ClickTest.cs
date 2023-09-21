using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickTest : MonoBehaviour
{
    public Tes[] _t;

    public LayerMask l;

    Material m;

    public bool mainMenu = false;
    public bool sc1 = false;


    private void Awake() {
        m = GetComponent<SpriteRenderer>().material;
    }

    private void OnMouseDown() {
        if(mainMenu) {
            FadeManager.Instance.anim.SetTrigger("Fade");
            Invoke(nameof(Load),.5f);
        }
        if(sc1){
            // FadeManager.Instance.anim.SetTrigger("Fade");
            Invoke(nameof(Load2),.5f);
        }
        Debug.Log("Click! " + gameObject.name);
    }

    private void Load(){SceneManager.LoadScene(1);}
    private void Load2(){SceneManager.LoadScene(2);}

    private void OnMouseEnter() {
        m.SetFloat("_Scale", 10f);
    }
    private void OnMouseExit() {
        m.SetFloat("_Scale", 0f);
    }
}

[System.Serializable]
public class Tes{
    public Tes[] _tes;
}