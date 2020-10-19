using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animator animator
    {
        get
        {
            if (_animator == null)
                _animator = GetComponent<Animator>();
            return _animator;
        }
    }
    private Animator _animator;

    [SerializeField]
    private string m_StateName;


    public void Play()
    {
        if (string.IsNullOrEmpty(m_StateName))
            return;
        animator.Play(m_StateName);
    }
}
