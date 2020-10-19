using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : ObjectPool
{
    public override void OnReUse(GameObject obj)
    {
        if (_TryGetParticle(obj, out ParticleSystem ps))
        {
            ps.Play();
        }
    }

    private bool _TryGetParticle(GameObject go, out ParticleSystem ps)
    {
        ps = go.GetComponent<ParticleSystem>();
        return ps != null;
    }
}
