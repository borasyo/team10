using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRainEffect : EventBase
{
    ParticleSystem _effect = null;
    [SerializeField] GameObject _explosionPrefab = null;

    /// <summary>
    /// 生成時処理
    /// </summary>
    void Start () 
    {
        _effect = GetComponentInChildren<ParticleSystem>();
        transform.position = new Vector3(-0.77f, -0.5f, 0);
        StartCoroutine(ExplosionSound());
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

    IEnumerator ExplosionSound()
    {
        yield return new WaitForSeconds(2.75f);

        while (true)
        {
            if (Random.Range(0, 10) == 0)
            {
                Instantiate(_explosionPrefab);
            }
            yield return null;
        }
    }
}
