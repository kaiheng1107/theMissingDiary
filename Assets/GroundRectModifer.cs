using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRectModifer : MonoBehaviour
{
    [SerializeField]
    private RectTransform m_Town;
    [SerializeField]
    private Vector2 m_Resolution;
    void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        float newWidth = Display.main.renderingHeight - m_Town.rect.height;
        rt.sizeDelta = new Vector2(newWidth, newWidth * m_Resolution.y / m_Resolution.x);
    }
}
