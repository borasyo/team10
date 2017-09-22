using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadText : MonoBehaviour
{
    private Text _text = null;

    /// <summary>
    /// 生成時処理
    /// </summary>
    private void Start()
    {
        _text = GetComponent<Text>();
        StartCoroutine(Run());
    }

    /// <summary>
    /// 実行処理
    /// </summary>
    private IEnumerator Run()
    {
        const string LoadingFormat = "Loading{0}";
        string tenten = ""; // Loading (...)←の情報を保持

        while(true)
        {
            int count = 0;
            while (count < 4)
            {
                _text.text = string.Format(LoadingFormat, tenten);
                tenten += ".";
                count ++;
                yield return new WaitForSeconds(0.5f);
            }
            tenten = "";
        }
    }
}
