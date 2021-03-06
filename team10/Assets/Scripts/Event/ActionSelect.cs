﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSelect : EventBase
{
    #region define

    const string OnSelect = "▷";
    const string ActionSelectFormat = "　{0}攻撃　{1}防御　{2}逃げる　";

    #endregion

    // 継続時間
    public float Time { private get; set; }

    // 選択の待機時間
    [SerializeField] private float min = 0.5f;
    [SerializeField] private float max = 1.5f;

    // カーソル移動サンド
    [SerializeField] AudioSource _se = null;

    /// <summary>
    /// 生成時処理
    /// </summary>
	private void Start ()
    {
        StartCoroutine(Run());	
	}

    /// <summary>
    /// 実行処理
    /// </summary>
    private IEnumerator Run()
    {
        // 初期化処理
        float remainTime = Time - Random.Range(min, max);
        int index = 0;
        TextAnimator.Instance.DirectInsertMassage(CreateInsertMessage(index));
        yield return new WaitForSeconds(Time - remainTime);

        // 実行 
        while (remainTime > 0.0f)
        {
            float waitTime = 0.0f;
            if (remainTime >= max)
            {
                waitTime = Random.Range(min, max);
                index += Random.Range(0, 2) == 0 ? -1 : 1;
                if (index < 0) index = 2;
                else if (index > 2) index = 0;
            }
            else
            {
                waitTime = remainTime;
                index = 0;
            }

            remainTime -= waitTime;
            TextAnimator.Instance.DirectInsertMassage(CreateInsertMessage(index));
            _se.Play();
            yield return new WaitForSeconds(waitTime);
        }

        // 終了処理
        EventEnd = true;
    }

    /// <summary>
    /// 送信する文字列を生成
    /// </summary>
    private string CreateInsertMessage(int index)
    {
        string atk = "　";
        string def = "　";
        string esc = "　";

        switch(index)
        {
            case 0:
                atk = OnSelect;
                break;
            case 1:
                def = OnSelect;
                break;
            case 2:
                esc = OnSelect;
                break;
        }
        return string.Format(ActionSelectFormat, atk, def, esc);
    }

}
