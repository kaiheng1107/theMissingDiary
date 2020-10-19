using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class FadeOutController : MonoBehaviour
{
    private Renderer[] allRenders;
    [Range(0,1)]
    public float TargetAlpha;
    private void Awake()
    {
        allRenders = GetComponentsInChildren<Renderer>();
    }

    private void LateUpdate()
    {
        if (IsUpdate)
        {
            if (TargetAlpha < 1.0f)
            {
                SetMaterialTransparent();
                SetMaterialAlpha();
            }
            else
            {
                SetMaterialOpaque();
            }
        }
    }

    private bool IsUpdate
    {
        get
        {
            return allRenders[0].material.color.a != TargetAlpha;
        }
    }

    private void SetMaterialAlpha()
    {
        foreach (var render in allRenders)
        {
            foreach (var material in render.materials)
            {
                var clr = material.color;
                clr.a = TargetAlpha;
                material.color = clr;
            }
        }
    }
    private void SetMaterialTransparent()
    {
        foreach (var render in allRenders)
        {
            foreach (var material in render.materials)
            {
                material.SetFloat("_Mode", 3);
                material.SetInt("_SrcBlend", (int)BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 1);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
            }
        }
    }
    private void SetMaterialOpaque()
    {
        foreach (var render in allRenders)
        {
            foreach (var material in render.materials)
            {
                material.SetInt("_SrcBlend", (int)BlendMode.One);
                material.SetInt("_DstBlend", (int)BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = -1;
            }
        }
    }
}
