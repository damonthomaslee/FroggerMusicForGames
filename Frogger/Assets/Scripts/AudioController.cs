using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

class AudioController : MonoBehaviour
{
    public GameObject MusicControllerObject;
    
    private static AudioController _instance;

    public static AudioController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioController>();
                if (_instance == null)
                {
                    var go = new GameObject("__AUDIO_CONTROLLER__");
                    _instance = go.AddComponent<AudioController>();
                }
            }

            return _instance;
        }
    }

    private AudioSource _audioSource;
    private AudioSource AudioSource
    {
        get
        {
            if (_audioSource == null)
            {
                _audioSource = GetComponent<AudioSource>();
            }
            return _audioSource;
        }
    }

    public AudioClip leap;
    public AudioClip squish;
    public AudioClip splash;
    public AudioClip home;
    public AudioClip endOfRound;
    public AudioClip gameOverSound;
    
    public void PlayLeap()
    {
        AudioSource.PlayOneShot(leap);
    }

    public void PlaySquish()
    {
        
        AudioSource.PlayOneShot(squish);
    }

    public void PlayDrown()
    {
        AudioSource.PlayOneShot(splash);
    }

    public void PlayHome()
    {
        AudioSource.PlayOneShot(home);
    }

    public void PlayEndOfRound(Action action)
    {
        //Lee Added
        Destroy(MusicControllerObject);
        StartCoroutine(CRPlayEndOfRound(action));
        
    }

    public void GameOverSequence()
    {
        Destroy(MusicControllerObject);
        _audioSource.PlayOneShot(gameOverSound, .5f );
        StartCoroutine(WaitAndLoadAttractMode());
    }

    private IEnumerator CRPlayEndOfRound(Action action)
    {
        
        
        AudioSource.PlayOneShot(endOfRound);
       //original
        //yield return new WaitForSeconds(endOfRound.length);
        
        //Lee Added
        yield return new WaitForSecondsRealtime(endOfRound.length);
        
        action?.Invoke();
        // added following from game manager and added here 
        SceneManager.LoadScene("Game");
    }
    IEnumerator WaitAndLoadAttractMode()
    {
        yield return new WaitForSeconds(gameOverSound.length + 2.0f);
        SceneManager.LoadScene("AttractMode");
    }
}
