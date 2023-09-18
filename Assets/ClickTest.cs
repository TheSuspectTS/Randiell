using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTest : MonoBehaviour
{
    Material m;

    private void Awake() {
        m = GetComponent<SpriteRenderer>().material;
    }

    private void OnMouseDown() {
        Debug.Log("Click! " + gameObject.name);
    }

    private void OnMouseEnter() {
        m.SetFloat("_Scale", 10f);
    }
    private void OnMouseExit() {
        m.SetFloat("_Scale", 0f);
    }
}
