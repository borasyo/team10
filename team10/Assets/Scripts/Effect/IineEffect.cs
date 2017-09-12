using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IineEffect : EventBase
{
    Sprite _sprite = null;
    ParticleSystem _effect = null;

    /// <summary>
    /// 初期化処理
    /// </summary>
    void Start ()
    {
        _effect = GetComponentInChildren<ParticleSystem>();
	}

    /// <summary>
    /// 更新処理
    /// </summary>
    void Update ()
    {
        if (_effect.isPlaying)
            return;

        // 終了
        EventEnd = true;
    }
}
