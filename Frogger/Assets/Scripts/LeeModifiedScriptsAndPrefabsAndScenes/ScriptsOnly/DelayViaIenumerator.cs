using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayViaIenumerator : MonoBehaviour
{
    // Start is called before the first frame update
    public float delayTimeinSec = 0.2f;
    
    AudioSource m_MyAudioSource;

    
    // Start is called before the first frame update
    void Awake()
    {
        //Fetch the AudioSource from the GameObject
        m_MyAudioSource = GetComponent<AudioSource>();

        StartCoroutine(playDelayedSound());
    }

    IEnumerator playDelayedSound()
    {
        yield return new WaitForSeconds(delayTimeinSec);
        m_MyAudioSource.Play();
    }
}

