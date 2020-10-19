using UnityEngine;

public class MusicNoteSpawner : MonoBehaviour
{
    public ObjectPool pool;
    [SerializeField]
    private Camera m_Cam; 

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = m_Cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out RaycastHit hit))
                pool.ReUse(hit.point, transform.rotation);
        }
    }
}
