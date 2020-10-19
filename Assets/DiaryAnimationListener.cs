using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiaryAnimationListener : MonoBehaviour
{
    public UnityEvent OnPlayFlickOverBegin = new UnityEvent();
    public void FlickOverSubevent()
    {
        OnPlayFlickOverBegin?.Invoke();

    }
}
