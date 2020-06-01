using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBasic : MonoBehaviour 

{
  


    public static SingletonBasic Instance = null;
	
    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad (gameObject);
    }
    
}
    