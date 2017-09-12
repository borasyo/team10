using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // イベントプレハブのパス、{0}にはEventIDを入れる
    const string EventPrefabPath = "Prefabs/Event/eventID_{0}";

    // ここから情報を取得し、ゲームを進行する
    Queue<GameDataMaster> _gameDataQueue = new Queue<GameDataMaster>();

    // ゲーム中メッセージを表示する際のText
    [SerializeField] Text _name = null;
    [SerializeField] TextAnimator _message = null;

    #region unity_event

    /// <summary>
    /// 生成時処理
    /// </summary>
    private void Awake ()
    { 
        // データを読み込む
        GameDataMasterTable masterTable = new GameDataMasterTable();
        masterTable.Load();

        // キューに格納
        foreach (GameDataMaster master in masterTable.All)
        {
            _gameDataQueue.Enqueue(master);
        }

        // ゲームループ開始
        StartCoroutine(GameLoop());
    }

    #endregion

    #region coroutine

    /// <summary>
    /// ゲームを進行する
    /// </summary>
    private IEnumerator GameLoop ()
    {
        Debug.Log("開始");

        // 上から順に実行
        while (_gameDataQueue.Count > 0)
        {
            GameDataMaster data = _gameDataQueue.Dequeue();
            _name.text = data.Name;

            // メッセージはアニメーションさせる
            var messageAnimation = StartCoroutine(_message.Run(data.Message));
            Debug.Log(data.Name + "のセリフ再生");
            yield return messageAnimation;
            Debug.Log(data.Name + "のセリフ終了");

            // イベントがあれば再生し、再生終了を待つ
            if (data.EventID >= 0)
            {
                var eventPrefab = Resources.Load(string.Format(EventPrefabPath, data.EventID.ToString())) as GameObject;
                var eventBase = Instantiate(eventPrefab).GetComponent<EventBase>();
                eventBase.Init(data.Name);
                Debug.Log(eventBase.name + "再生");
                yield return new WaitWhile(() => !eventBase.EventEnd);
                Destroy(eventBase.gameObject);
            }
            // 再生しない場合、1秒だけ待つ
            else
            {
                Debug.Log("eventはなし");
                yield return new WaitForSeconds(1.0f);
            }
        }

        // ゲーム終了
        // TODO : 何か実装
        yield return new WaitForSeconds(1.0f);
        Debug.Log("終了");
        UnityEditor.EditorApplication.isPlaying = false;
        yield break;
	}

    #endregion 
}
