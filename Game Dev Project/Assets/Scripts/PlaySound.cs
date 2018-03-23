using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFire : MonoBehaviour
{

    public AudioClip soundClip;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SoundController.me.PlaySound(soundClip);
        }
    }
}