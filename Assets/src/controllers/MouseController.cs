﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour {

  // The world-position of the mouse last frame.
  Vector3 lastFramePosition;
  Vector3 currFramePosition;

  // Update is called once per frame
  void Update () {
    currFramePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
    currFramePosition.z = 0;

    UpdateCameraMovement();

    // Save the mouse position from this frame
    // We don't use currFramePosition because we may have moved the camera.
    lastFramePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
    lastFramePosition.z = 0;
  }
    
  void UpdateCameraMovement() {
    Camera.main.orthographicSize -= Camera.main.orthographicSize * Input.GetAxis("Mouse ScrollWheel");
    Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 2f, 25f);

    // Handle screen panning
    if( Input.GetMouseButton(1) || Input.GetMouseButton(2) ) {  // Right or Middle Mouse Button

      Vector3 diff = lastFramePosition - currFramePosition;
      Camera.main.transform.Translate( diff );

    }
  }
}