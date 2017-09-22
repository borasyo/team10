using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLoadNextScene : MonoBehaviour
{
    [SerializeField] private float Time = 2.0f;
    [SerializeField] private string SceneName = "読み込むシーンの名前入れて";

    /// <summary>
    /// 生成時処理
    /// </summary>
    private void Start()
    {
        StartCoroutine(NextScene());
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(Time);
        SceneChanger.Instance.ChangeScene(SceneName, 1.0f, true);
    }
}
