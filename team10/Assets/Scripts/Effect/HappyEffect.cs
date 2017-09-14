using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyEffect : EventBase
{
    //[SerializeField] GameObject _happyBeam = null;
    [SerializeField] GameObject _happyEffectPrefab = null;

    /// <summary>
    /// 生成時処理
    /// </summary>
    private void Start()
    {
        StartCoroutine(Run());
    }

    /// <summary>
    /// エフェクト再生
    /// </summary>
    private IEnumerator Run()
    {
        // はっぴーむを飛ばす処理
        float time = 0.0f;
        Vector3 targetPos = CharacterManager.Instance.GetCharacter(GameDefine.Soyaman).position;
        Vector3 startPos = transform.position;

        while (time < 1.0f)
        {
            time += Time.deltaTime; // * 2.0f;
            transform.position = Vector3.Lerp(startPos, targetPos, time);
            transform.eulerAngles += new Vector3(0, 0, 12);
            yield return null;
        }

        // エフェクト再生
        //Destroy(_happyBeam);
        ParticleSystem healEffect = Instantiate(_happyEffectPrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        healEffect.transform.SetParent(transform);
        yield return new WaitWhile(() => healEffect.isPlaying);

        // 終了
        EventEnd = true;
    }
}
