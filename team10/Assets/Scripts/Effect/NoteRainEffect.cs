using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRainEffect : EventBase
{
    ParticleSystem _effect = null;

    /// <summary>
    /// 生成時処理
    /// </summary>
    void Start () 
    {
        _effect = GetComponentInChildren<ParticleSystem>();
        transform.position = new Vector3(-0.77f, -0.5f, 0);
	}

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update ()
    {
        if (_effect.isPlaying)
            return;

        EventEnd = true;
	}
}
