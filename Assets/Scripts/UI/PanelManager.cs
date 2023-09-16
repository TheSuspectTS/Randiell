using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject[] panels;

    public void OpenPanel(GameObject _panel){
        foreach(GameObject _p in panels) _p.SetActive(false);
        _panel.SetActive(true);
    }
}
