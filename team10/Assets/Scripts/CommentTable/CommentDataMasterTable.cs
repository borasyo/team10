using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CommentDataMasterTable : CommentTableBase<CommentDataMaster>
{
	private static readonly string URL = 
        "https://docs.google.com/spreadsheets/d/1ocMc9OAxXa8hUTciVw5ocFMEBBI6XOPHoMG8qkvapqI/export?format=csv";

	private IObservable<Unit> _loadObservable;
    /// <summary>
    /// ロードの完了を通知してくれるObservar．
    /// Subscribeすれば完了後に実行される．
    /// </summary>
    /// <value>The load observable.</value>
	public IObservable<Unit> LoadObservable
	{
		get
		{
            return _loadObservable ?? (_loadObservable = Observable.FromCoroutine(() => LoadAsyncCorutine(URL)).PublishLast().RefCount());
		}
	}
}

public class CommentDataMaster : MasterBase
{
    public override void Load(string[] elements)
    {
        ActionID = int.Parse(elements[0]);
        TimeToFlow = float.Parse(elements[1]);
        FlowingTime = float.Parse(elements[2]);
        Comment = elements[3];
        CommentColor = ColorParser.ToColorOrWhite(elements[4]);
        bool tempBool;
        IsBold = bool.TryParse(elements[5], out tempBool);
    }
    public int ActionID { get; private set; }
    public float TimeToFlow { get; private set; } //流れるのにかかる時間
    public float FlowingTime { get; private set; } //アクション開始からコメントが流れるまでの時間
    public string Comment { get; private set; } 
    public Color CommentColor { get; private set; } //コメントの色
    public bool IsBold { get; private set; } //太字にするかどうか
}
