using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Comment : MonoBehaviour
{

    Vector3 startPos = new Vector3(9, 0, 0);
    Vector3 endPos;
    CommentDataMaster commendData;
    TextMesh textMesh;
    float startTime;

    private void Awake()
    {
        textMesh = GetComponent<TextMesh>();
    }

    private void OnEnable()
    {
        startTime = Time.timeSinceLevelLoad;
        transform.position = startPos;
    }

    private void Start()
    {
        endPos = new Vector3(-TextMeshUtil.GetWidth(textMesh) * transform.localScale.x - 9, startPos.y, 0);
        textMesh.text = commendData.Comment;
        textMesh.color = commendData.CommentColor;
        if (commendData.IsBold) textMesh.fontStyle = FontStyle.Bold;
    }

    private void Update()
    {
        var diff = Time.timeSinceLevelLoad - commendData.FlowingTime - startTime;

        var rate = diff / commendData.TimeToFlow;

        transform.position = Vector3.Lerp(startPos, endPos, rate);

        if (rate > 1)
        {
            Destroy(this.gameObject);
        }
    }

    public void Init(CommentDataMaster commentData, float posY)
    {
        this.commendData = commentData;
        startPos.y = posY;
    }
}
