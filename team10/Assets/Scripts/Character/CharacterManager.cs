using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // インスタンス取得
    private static CharacterManager instance = null;
    public static CharacterManager Instance { get { return instance; } }

    // キャラのスプライトを保持   
    private Sprite[] _charaSprite      = new Sprite[7];
    private Sprite[] _charaAtackSprite = new Sprite[7];
    private SpriteRenderer[] _nowCharaSpRend = new SpriteRenderer[7];

    /// <summary>
    /// 生成時処理
    /// </summary>
    private void Awake()
    {
        instance = this;
        LoadChara();
    }

    #region CharaData

    /// <summary>
    /// キャラ情報を処理
    /// </summary>
    public Transform GetCharacter(string name)
    {
        string findName = "";
        switch(name)
        {
            case GameDefine.Bora:
                findName = "bora";
                break;
            case GameDefine.Yukka:
                findName = "yukka";
                break;
            case GameDefine.Ran:
                findName = "ran";
                break;
            case GameDefine.Kuririn:
                findName = "kuririn";
                break;
            case GameDefine.Kouchan:
                findName = "kouchan";
                break;
            case GameDefine.Bahha:
                findName = "bahha";
                break;
            case GameDefine.Soyaman:
                findName = "maou_soyaman";
                break;
        }
        Debug.Log(findName);
        return transform.Find(findName);
    }

    /// <summary>
    /// キャラのインデックスを取得
    /// </summary>
    private int GetIndex(string name)
    {
        int index = 0;
        switch (name)
        {
            case GameDefine.Bora:
                index = 0;
                break;
            case GameDefine.Kouchan:
                index = 1;
                break;
            case GameDefine.Yukka:
                index = 2;
                break;
            case GameDefine.Ran:
                index = 3;
                break;
            case GameDefine.Kuririn:
                index = 4;
                break;
            case GameDefine.Bahha:
                index = 5;
                break;
            case GameDefine.Soyaman:
                index = 6;
                break;
        }
        return index;
    }

    #endregion

    #region CharaSprite

    /// <summary>
    /// キャラのスプライトをロード
    /// </summary>
    private void LoadChara()
    {
        string path = "Texture/Character/";
        string[] resourceName = new string[7] { "bora", "yukka", "ran", "kuririn", "kouchan", "bahha", "soyaman" };

        for (int i = 0; i < 7; i++)
        {
            _nowCharaSpRend[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
            _charaSprite[i] = Resources.Load<Sprite>(path + resourceName[i]);
            _charaAtackSprite[i] = Resources.Load<Sprite>(path + resourceName[i] + "_atack");
        }
    }

    /// <summary>
    /// 指定したキャラの状態をIdleに変更
    /// </summary>
    public void ChangeIdleChara(string name)
    {
        int index = GetIndex(name);
        _nowCharaSpRend[index].sprite = _charaSprite[index];

        // TODO ; 見やすくするため 
        _nowCharaSpRend[index].color = Color.white;
    }

    /// <summary>
    /// 指定したキャラの状態をAtackに変更
    /// </summary>
    public void ChangeAtackChara(string name)
    {
        int index = GetIndex(name);
        _nowCharaSpRend[index].sprite = _charaAtackSprite[index];

        // TODO ; 見やすくするため 
        _nowCharaSpRend[index].color = Color.red;
    }

    #endregion
}
