using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAudioDelay : MonoBehaviour
{
    public float delayTimeinSec = 0.2f;
    
    AudioSource m_MyAudioSource;

    
    // Start is called before the first frame update
    void Awake()
    {
        //Fetch the AudioSource from the GameObject
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.PlayDelayed(delayTimeinSec);
    }


}
