using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBase : MonoBehaviour
{
    // Event終了フラグ
    private bool _end = false;
    public bool EventEnd { get { return _end; } protected set { _end = value; } }

    // Event再生キャラの名前
    protected string _name;

    #region unity_event

    /// <summary>
    /// 初期化処理
    /// </summary>
    public void Init(string name)
    {
        _name = name;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        // Debugコマンド
        if (!Input.GetKeyDown(KeyCode.Q))
            return;

        EventEnd = true;
        Debug.Log(name + "終了");
    }

    #endregion
}
