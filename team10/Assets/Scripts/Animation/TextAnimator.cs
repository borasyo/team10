﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimator : MonoBehaviour
{
    // インスタンス取得
    private static TextAnimator instance = null;
    public static TextAnimator Instance { get { return instance; } }

    // 表示用Text
    [SerializeField] Text _text = null;

    // 表示間隔
    [SerializeField] float _interval = 0.1f;

    // SEがあれば再生
    [SerializeField] AudioSource _se = null;

    /// <summary>
    /// 生成時処理
    /// </summary>
    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// アニメーション実行
    /// </summary>
    public IEnumerator Run(string message)
    {
        // 初回リセット
        _text.text = "";

        // アニメーション実行！
        int loopCount = 1;
        while (loopCount < message.Length)
        {
            // テキストを更新
            _text.text = message.Substring(0, loopCount);

            // SEあれば再生
            if (_se)
                _se.Play();

            int lastIndex = _text.text.Length - 1;
            if (_text.text.Substring(lastIndex) == "！" &&
                message.Substring(loopCount, 1) != "！")
            {
                // ！なので、少し多めに待つ
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                // 指定秒数待ち、カウントを増加
                yield return new WaitForSeconds(_interval);
            }
            loopCount++;
        }
    }

    /// <summary>
    /// アニメーションなしで文字列を変更
    /// </summary>
    public void DirectInsertMassage(string message)
    {
        _text.text = message;
    }
}
