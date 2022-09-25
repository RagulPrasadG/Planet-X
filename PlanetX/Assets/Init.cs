using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{

    [SerializeField] GameObject audioManager;
    private void Start()
    {
        var audio = FindObjectOfType<AudioScript>();

        if(audio == null)
        Instantiate(audioManager);
    }
   
}
