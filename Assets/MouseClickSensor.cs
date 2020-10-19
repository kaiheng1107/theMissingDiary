using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickSensor : MonoBehaviour
{
    [SerializeField]
    private DiaryFXController m_Controller;

    private void OnMouseDown()
    {
        if (m_Controller == null) return;
        switch (m_Controller.CurrentMode)
        {
            case DiaryFXController.ControllerMode.StandyBy:
                m_Controller.PlayAnimation();
                break;
            case DiaryFXController.ControllerMode.Play:
                m_Controller.Reset();
                break;
        }
    }
}
