using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AllAtack : EventBase
{
    // イベントプレハブのパス、{0}にはEventIDを入れる
    const string EventPrefabPath = "Prefabs/Event/eventID_{0}";

    [SerializeField] float _interval = 0.5f;

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
        List<Coroutine> _allList = new List<Coroutine>();

        _allList.Add(StartCoroutine(PlayEffect(GameDefine.Bahha, 4)));
        yield return new WaitForSeconds(_interval);
        _allList.Add(StartCoroutine(PlayEffect(GameDefine.Ran, 0)));
        yield return new WaitForSeconds(_interval);
        _allList.Add(StartCoroutine(PlayEffect(GameDefine.Kuririn, 1)));
        yield return new WaitForSeconds(_interval);
        _allList.Add(StartCoroutine(PlayEffect(GameDefine.Yukka, 3)));
        yield return new WaitForSeconds(_interval);
        _allList.Add(StartCoroutine(PlayEffect(GameDefine.Kouchan, 2)));

        // 全て終了するまで待つ
        while (_allList.Count > 0)
        {
            yield return _allList[0];
            _allList.RemoveAt(0);
        }

        EventEnd = true;
    }

    private IEnumerator PlayEffect(string charaName, int id)
    {
        var eventPrefab = Resources.Load(string.Format(EventPrefabPath, id)) as GameObject;
        var eventBase = Instantiate(eventPrefab).GetComponent<EventBase>();
        eventBase.Init(charaName);
        yield return new WaitWhile(() => !eventBase.EventEnd);
        Destroy(eventBase.gameObject);
    }
}
