using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiotest : MonoBehaviour
{

    public AudioManager audio_manager;
    // Start is called before the first frame update
    void Start()
    {

        audio_manager.Play("BackGroundMusic");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
