using System;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(HighLightEffectController))]
public class DiaryFXController : MonoBehaviour
{
    public enum ControllerMode
    {
        StandyBy,
        Play
    }

    [SerializeField]
    private DiaryAnimationListener m_DiaryAnimationListener;
    [SerializeField]
    private HighLightEffectController m_HighlightController;
    [SerializeField]
    private ParticleSystem m_TwisterParticleSystem;
    [SerializeField]
    private ForceFieldController m_ForceFieldController;
    [SerializeField]
    private AnimatorState[] m_AnimatorStates;

    public ControllerMode CurrentMode { get; private set; } = ControllerMode.StandyBy;

    private void Start()
    {
        m_DiaryAnimationListener.OnPlayFlickOverBegin.AddListener(PlayOverLayHighlight);
    }
    public void PlayOverLayHighlight()
    {
        m_HighlightController?.SetOverLayHighlight();
    }

    public async void PlayAnimation()
    {
        if (CurrentMode == ControllerMode.Play) Reset();
        CurrentMode = ControllerMode.Play;

        for (int i = 0; i < m_AnimatorStates.Length; i++)
        {
            var state = m_AnimatorStates[i];
            if (state == null
                || state.animator == null
                || state.stateName == null) continue;

            state.animator.Play(state.stateName);
            var info = state.animator.GetCurrentAnimatorStateInfo(0);
            int milliseconds = (int)info.length * 1000 - 500;
            await Task.Delay(milliseconds);
        }
    }

    public void PlayHighlightVFX()
    {
        m_HighlightController?.SetHighlight();
    }

    public void PlayTwisterVFX()
    {
        m_TwisterParticleSystem?.Play();
        m_ForceFieldController?.Play();
    }

    public void Reset()
    {
        CurrentMode = ControllerMode.StandyBy;
        foreach (var i in m_AnimatorStates)
        {
            if (i.animator != null)
                i.animator.Play(i.idleName);
        }
        m_ForceFieldController?.Reset();
        m_HighlightController?.Reset();
    }

    [System.Serializable]
    public class AnimatorState
    {
        public Animator animator;
        public string stateName;
        public string idleName;
    }
}
