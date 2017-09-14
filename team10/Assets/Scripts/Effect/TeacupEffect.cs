using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacupEffect : EventBase
{
    [SerializeField] float _speed = 2.0f;
    [SerializeField] GameObject _teaCup = null;
    [SerializeField] GameObject _healEffectPrefab = null;

    /// <summary>
    /// 生成時処理
    /// </summary>
    private void Start ()
    {
        StartCoroutine(Run());
	}

    /// <summary>
    /// エフェクト再生
    /// </summary>
    private IEnumerator Run()
    {
        // Teacupを飛ばす処理
        float time = 0.0f;
        Vector3 targetPos = CharacterManager.Instance.GetCharacter(GameDefine.Soyaman).position;
        Vector3 startPos = transform.position;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(targetPos.y - startPos.y, targetPos.x - startPos.x) * Mathf.Rad2Deg - 180);
        
        while (time < 1.0f)
        {
            time += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(startPos, targetPos, time);
            //transform.eulerAngles += new Vector3(0,0,12);
            yield return null;
        }

        // 回復エフェクト再生
        Destroy(_teaCup);
        ParticleSystem healEffect = Instantiate(_healEffectPrefab, targetPos, Quaternion.identity).GetComponent<ParticleSystem>();
        healEffect.transform.SetParent(transform);
        yield return new WaitWhile(() => healEffect.isPlaying);

        // 終了
        EventEnd = true;
    }
}
