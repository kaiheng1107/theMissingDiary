using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SomiRectModifer : MonoBehaviour
{
    [SerializeField]
    private Vector2 m_Resolution;
    private RectTransform rt;
    private void Start()
    {
        rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(0, rt.rect.width * m_Resolution.y / m_Resolution.x);
    }
}
