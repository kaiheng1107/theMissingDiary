using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class followTest : MonoBehaviour
{
    RectTransform rt;
    public GameObject _herz;
    public Camera _cam;
    public Canvas _canvas;
    RectTransform canRT;


    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        canRT = _canvas.GetComponent<RectTransform>();
    }
    
    // Update is called once per frame
    void Update()
    {
        var screenPt = RectTransformUtility.WorldToScreenPoint(_cam, _herz.transform.position);
        rt.anchoredPosition = screenPt - canRT.sizeDelta/2f;
    }
}
