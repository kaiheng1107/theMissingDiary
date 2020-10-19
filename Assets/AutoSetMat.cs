using UnityEngine;

public class AutoSetMat : MonoBehaviour
{
    [SerializeField]
    private Material m_Material;
    [SerializeField]
    private string m_Path;
    [SerializeField]
    private string m_CustomBookName;
    [SerializeField]
    private Material[] m_BookMaterial;

    public string Path { get => m_Path; }
    public void SetMaterials(Material mat = null)
    {
        if (m_Material == null) return;
        var renders = GetComponentsInChildren<MeshRenderer>();
        if (renders != null && renders.Length > 0)
        {
            foreach (var i in renders)
            {
                i.material = m_Material;
            }
        }
    }
    public void SetBookMaterials()
    {
        var gos = GetComponentsInChildren<Transform>();
        foreach (var i in gos)
        {
            if (i.gameObject.name.Contains(m_CustomBookName))
            {
                var renders = i.GetComponentsInChildren<Renderer>();
                foreach (var j in renders)
                {
                    var index = Random.Range(0, m_BookMaterial.Length);
                    j.material = m_BookMaterial[index];
                }
            }
        }
    }
}
