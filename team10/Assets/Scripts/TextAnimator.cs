using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimator : MonoBehaviour
{
    // 表示用Text
    [SerializeField] Text _text = null;

    // 表示間隔
    [SerializeField] float _interval = 0.1f;

    // SEがあれば再生
    [SerializeField] AudioSource _se = null;

    /// <summary>
    /// アニメーション実行
    /// </summary>
    public IEnumerator Run(string message)
    {
        int loopCount = 0;
        while(loopCount < message.Length)
        {
            // テキストを更新
            _text.text = message.Substring(0, loopCount);

            // SEあれば再生
            if(_se)
                _se.Play();

            // 指定秒数待ち、カウントを増加
            yield return new WaitForSeconds(_interval);
            loopCount ++;
        }

        yield break;
    }
}
