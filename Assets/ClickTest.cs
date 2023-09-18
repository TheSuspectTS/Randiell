using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTest : MonoBehaviour
{
    private void OnMouseDown() {
        Debug.Log("Click! " + gameObject.name);
    }
}
