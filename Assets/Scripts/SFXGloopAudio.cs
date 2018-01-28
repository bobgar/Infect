﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXGloopAudio : MonoBehaviour {
    public AudioSource audioSource;
    public List<AudioClip> gloopSounds;

    private int gloopCount=0;

    public static SFXGloopAudio instance;

	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayGloop()
    {
        gloopCount++;
        if (gloopCount > gloopSounds.Count)
            gloopCount = 0;

        audioSource.clip = gloopSounds[gloopCount];
        audioSource.Play();
    }
}