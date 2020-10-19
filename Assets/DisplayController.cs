using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var cam = GetComponent<Camera>();
        if (Display.displays.Length > cam.targetDisplay)
            Display.displays[cam.targetDisplay].Activate();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
