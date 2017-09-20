using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UniRx;


public class CommentTableBase<T> where T : MasterBase, new()
{
    protected List<T> masters;
    public List<T> All { get { return masters; } }

    /// <summary>
    /// データの読み込み．
    /// wwwアクションを伴うので非同期で行う．
    /// </summary>
    /// <returns>The async corutine.</returns>
    /// <param name="URL">URL.</param>
    protected IEnumerator LoadAsyncCorutine(string URL)
    {
        var www = new WWW(URL);
        yield return www;

        var text = www.text;

		text = text.Trim().Replace("\r", "") + "\n";
		var lines = text.Split('\n').ToList();

		// header
		var headerElements = lines[0].Split(',');
		lines.RemoveAt(0); // header

		// body
		masters = new List<T>();
		foreach (var line in lines)
		{
			ParseLine(line, headerElements);
		}

        yield return null;
    }

    // MasterTableBaseと同じメソッドなのでなんとかしたい
    private void ParseLine(string line, string[] headerElements)
    {
        var elements = line.Split(',');
        if (elements.Length == 1)
            return;

        if (elements.Length != headerElements.Length)
        {
            Debug.LogWarning(string.Format("can't load: {0}", line));
            return;
        }

        var master = new T();
        master.Load(elements);
        masters.Add(master);
    }
}