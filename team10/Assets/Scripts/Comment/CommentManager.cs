using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using System.Linq;

/// <summary>
/// コメントマネージャ
/// シングルトンなので，GameControllerのAwakeからLoadが，GameLoopからInitCoometsが呼ばれることを想定．
/// </summary>
public class CommentManager : MonoBehaviour
{

    [SerializeField] GameObject commentObj;
    private List<CommentDataMaster> commentDatas = new List<CommentDataMaster>();

    #region Singleton
    private static CommentManager instance;
    public static CommentManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (CommentManager)FindObjectOfType(typeof(CommentManager));

                if (instance == null)
                {
                    Debug.LogError(typeof(CommentManager) + "is nothing");
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion


    /// <summary>
    /// グーグルスプレッドシートからデータをダウンロードし，そのデータをリストに格納
    /// </summary>
    public void Load()
    {
        var commentDataMasterTavle = new CommentDataMasterTable();
        commentDataMasterTavle.LoadObservable.Subscribe(_ =>
        { 
            foreach (CommentDataMaster master in commentDataMasterTavle.All)
            {
                commentDatas.Add(master);
            }
        });
    }

    /// <summary>
    /// Gameのアクションを起こすタイミングで呼ばれる
    /// アクション番号を入れることで該当するコメントを生成しデータを詰める．
    /// </summary>
    /// <param name="actionID">Action identifier.</param>
    public void InitComments(int actionID)
    {
        int posY = 2;
        foreach (var element in commentDatas.Where(data => data.ActionID == actionID).OrderBy(data => data.FlowingTime))
        {
            posY = ++posY % 4 + 2;
            Instantiate(commentObj).GetComponent<Comment>().Init(element, posY);
        }
    }
}