using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBase : MonoBehaviour
{
    // Event終了フラグ
    protected bool _end = false;
    public bool End { get { return _end; } private set { _end = value; } }

    private void Update()
    {
        // Debugコマンド
        if (!Input.GetKeyDown(KeyCode.Q))
            return;

        End = true;
        Debug.Log("Event終了");
    }
}
