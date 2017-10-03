using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class MasterTableBase<T> where T : MasterBase, new()
{
    protected List<T> masters = new List<T>();
    public List<T> All { get { return masters; } }

    public IEnumerator LoadCourutine(string URL)
    {
        Debug.Log("a");
        var www = new WWW(URL);
        yield return www;

        var text = www.text;
        //var text = ((TextAsset)Resources.Load(filePath, typeof(TextAsset))).text;

        text = text.Trim().Replace("\r", "") + "\n";
        var lines = text.Split('\n').ToList();

        // header
        var headerElements = lines[0].Split(',');
        lines.RemoveAt(0); // header

        // body
        //masters = new List<T>();
        foreach (var line in lines)
        {
            ParseLine(line, headerElements);
        }
    }

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

public class MasterBase
{
    public virtual void Load(string[] elements)
    {
        // 継承先で記述する
    }
}