using MirzaBeig.Scripting.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystemForceField))]
public class ForceFieldController : MonoBehaviour
{
    private ParticleSystemForceField forceField;

    [SerializeField]
    private float m_MaxRange;
    [SerializeField]
    private float m_TotalTime;
    [SerializeField]
    private AnimationCurve m_Curve;
    private Coroutine m_IncreaseMistRadialVelocityCorountine;

    private void Start()
    {
        forceField = GetComponent<ParticleSystemForceField>();
    }

    public void Play()
    {
        if (m_IncreaseMistRadialVelocityCorountine != null) StopCoroutine(m_IncreaseMistRadialVelocityCorountine);
        m_IncreaseMistRadialVelocityCorountine = StartCoroutine(IncreaseMistRadialVelocity());
    }
    public void Reset()
    {
        forceField.endRange = 0.0f;
    }
    private IEnumerator IncreaseMistRadialVelocity()
    {
        float time = 0.0f;
        while (time < m_MaxRange)
        {
            forceField.endRange = m_Curve.Evaluate(time / m_TotalTime) * m_MaxRange;
            time += Time.deltaTime;
            yield return null;
        }
    }
}
