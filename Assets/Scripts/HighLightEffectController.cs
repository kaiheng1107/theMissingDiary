using HighlightPlus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightEffectController : MonoBehaviour
{
    [SerializeField]
    private HighlightProfile m_HighLightProfile;
    [SerializeField]
    private float m_TotalGlowingTime;
    [SerializeField]
    [Range(0, 5)]
    private float m_MaxGlowingVolume;
    [SerializeField]
    private Color m_GlowColor;
    [SerializeField]
    private AnimationCurve m_GlowCurve;

    [SerializeField]
    private float m_TotalOverlayTime;
    [SerializeField]
    [Range(0, 1)]
    private float m_MaxOverlayVolume;
    [SerializeField]
    private Color m_OverlayColor;
    [SerializeField]
    private AnimationCurve m_OverlayCurve;

    private HighlightEffect highlightEffect;
    private Coroutine increaseGlowingCorountine;
    private Coroutine increaseOverlayCorountine;


    private void Start()
    {
        Init();
    }

    private void Init()
    {
        highlightEffect = gameObject.AddComponent<HighlightEffect>();
        if (m_HighLightProfile)
        {
            highlightEffect.profile = m_HighLightProfile;
            m_HighLightProfile.Load(highlightEffect);
        }
        highlightEffect.SetHighlighted(false);
        highlightEffect.cullBackFaces = false;
        highlightEffect.glowQuality = HighlightPlus.QualityLevel.Highest;
        highlightEffect.glowHQColor = m_GlowColor;
        highlightEffect.overlay = 0.0f;
    }
    public void SetHighlight()
    {
        if (highlightEffect != null && highlightEffect.highlighted)
            highlightEffect.SetHighlighted(true);

        if (increaseGlowingCorountine != null) StopCoroutine(increaseGlowingCorountine);
        increaseGlowingCorountine = StartCoroutine(IncreaseGlowingVolume());
    }
    public void SetOverLayHighlight()
    {
        if (highlightEffect != null && !highlightEffect.highlighted)
            highlightEffect.SetHighlighted(true);

        if (increaseOverlayCorountine != null) StopCoroutine(increaseOverlayCorountine);
        increaseOverlayCorountine = StartCoroutine(IncreaseOverlayVolume());
    }

    public void Reset()
    {
        highlightEffect.glow = 0;
        highlightEffect.overlay = 0;
        highlightEffect.SetHighlighted(false);
    }
    private IEnumerator IncreaseGlowingVolume()
    {
        float time = 0.0f;
        while (time < m_TotalGlowingTime)
        {
            highlightEffect.glow = m_GlowCurve.Evaluate(time / m_TotalGlowingTime) * m_MaxGlowingVolume;
            time += Time.deltaTime;
            yield return null;
        }
        //m_HighLightEffect.SetHighlighted(false);
    }
    private IEnumerator IncreaseOverlayVolume()
    {
        float time = 0.0f;
        while (time < m_TotalOverlayTime)
        {
            highlightEffect.overlay = m_OverlayCurve.Evaluate(time / m_TotalOverlayTime) * m_MaxOverlayVolume;
            time += Time.deltaTime;
            yield return null;
        }
        //m_HighLightEffect.SetHighlighted(false);
    }

}