using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerEffect : EventBase
{
    [SerializeField] float _speed = 2.0f;
    [SerializeField] int _rotAmount = 36;
    [SerializeField] Vector3 _curve = new Vector3(5, 5, 0);

    [SerializeField] GameObject _ball = null;
    [SerializeField] GameObject _fireEffectPrefab = null;

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
        // Ballを飛ばす処理
        var Bezier = new BezierCurve.tBez();
        Bezier.t = 0.0f;
        Bezier.b0 = transform.position;
        Bezier.b1 = transform.position + _curve;
        Bezier.b2 = CharacterManager.Instance.GetCharacter(GameDefine.Soyaman).position;

        while (Bezier.t < 1.0f)
        {
            Bezier.t += Time.deltaTime * _speed;
            _speed += _speed * 0.1f;
            transform.position = BezierCurve.CulcBez(Bezier);
            //transform.eulerAngles += new Vector3(0, 0, _rotAmount);
            yield return null;
        }

        // 爆発エフェクト再生
        Destroy(_ball);
        ParticleSystem healEffect = Instantiate(_fireEffectPrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        healEffect.transform.SetParent(transform);
        yield return new WaitWhile(() => healEffect.isPlaying);

        // 終了
        EventEnd = true;
    }
}
