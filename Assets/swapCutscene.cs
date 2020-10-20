using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CinemaDirector;

public class swapCutscene : MonoBehaviour
{

    public Cutscene _cut1,_cut2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Swap()
    {
        _cut1.Pause();
        _cut2.Play();
    }
}
