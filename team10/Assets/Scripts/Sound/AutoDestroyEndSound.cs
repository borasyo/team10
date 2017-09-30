using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyEndSound : MonoBehaviour
{
    AudioSource _audioSource = null;

	//
	void Start ()
    {
        _audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (_audioSource.isPlaying)
            return;

        Destroy(gameObject);
	}
}
