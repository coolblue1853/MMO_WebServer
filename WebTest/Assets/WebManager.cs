using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class GameResult
{
    public string UserName;
    public int Score;
}

public class WebManager : MonoBehaviour
{
    string _baseUrl = "https://localhost:44316/api";
    void Start()
    {
        GameResult res = new GameResult()
        {
            UserName = "ASBD",
            Score = 333
        };

        SendPostRequest("ranking", res,(uwr) =>
        {
            Debug.Log("todo : UI 갱신");
        });
        SendGetAllRequest("ranking", (uwr) =>
        {
            Debug.Log("todo : UI 갱신");
        });
    }

    public void SendPostRequest(string url, object obj, Action<UnityWebRequest> callback)
    {
        StartCoroutine(CoSendWebRequest(url, "POST", obj,callback));
    }
    public void SendGetAllRequest(string url, Action<UnityWebRequest> callback)
    {
        StartCoroutine(CoSendWebRequest(url, "Get", null, callback));
    }

    // 123.123.123/api/변경부분
    //완료될때 callback을 연결할 수 있음.
    IEnumerator CoSendWebRequest(string url, string method, object obj, Action<UnityWebRequest> callback)
    {
        string sendUrl = $"{_baseUrl}/{url}/";

        byte[] jsonBytes = null;
        if(obj != null)
        {
            string jsonStr = JsonUtility.ToJson(obj);
            jsonBytes = Encoding.UTF8.GetBytes(jsonStr);
        }

        var uwr= new UnityWebRequest(sendUrl, method);
        uwr.uploadHandler = new UploadHandlerRaw(jsonBytes);
        uwr.downloadHandler = new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        yield return uwr.SendWebRequest();

        if(uwr.isNetworkError || uwr.isHttpError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            Debug.Log("Recv " + uwr.downloadHandler.text);
            callback.Invoke(uwr);
        }
    }
}
