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
        CharacterManager.Instance.ChangeAtackChara(_name);
        transform.position = CharacterManager.Instance.GetCharacter(_name).position;
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
        CharacterManager.Instance.ChangeIdleChara(_name);
        EventEnd = true;
    }
}
