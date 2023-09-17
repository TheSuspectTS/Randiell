using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MouseManager : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;

    public Camera cam;

    public Transform db;

    public float smt = 4;


    private void Update() {
        screenPosition = Input.mousePosition;

        worldPosition = cam.ScreenToWorldPoint(screenPosition*smt);

        db.position = new Vector2(worldPosition.x,worldPosition.y);

    }
}
