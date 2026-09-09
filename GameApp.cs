using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
public class GameApp : MonoBehaviour
{
    public void EnterGame()
    {
        StartCoroutine(GetBaidu());
        StartCoroutine(GetUpLoadData());
        StartCoroutine(ReadResVersion());
        StartCoroutine(DownloadResFile());
    }
    IEnumerator GetBaidu()
    {
        UnityWebRequest req = UnityWebRequest.Get("http://www.baidu.com");
        yield return req.SendWebRequest();  //不会卡住主线程


        Debug.Log("Success");
        Debug.Log(req.downloadHandler.text);
    }
    IEnumerator GetUpLoadData()
    {
        UnityWebRequest req = UnityWebRequest.Get("http://127.0.0.1:6080/uploadData?uname=jay&upwd=123456");
        yield return req.SendWebRequest();  


        Debug.Log(req.downloadHandler.text);
    }
    IEnumerator ReadResVersion()
    {
        UnityWebRequest req = UnityWebRequest.Get("http://127.0.0.1:6080/Version.txt");
        yield return req.SendWebRequest();

        Debug.Log(req.downloadHandler.text);
        yield break;
    }
    IEnumerator DownloadResFile()
    {
        string url = "http://127.0.0.1:6080/Photo/laoda.png";
        UnityWebRequest req = UnityWebRequest.Get(url);
        yield return req.SendWebRequest();

        byte[] body = req.downloadHandler.data;

        //保存到本地 c#读写文件
        string filePath = Application.persistentDataPath + "/laoda.png";
        System.IO.File.WriteAllBytes(filePath, body);
        Debug.Log("File saved to: " + filePath);
        yield break;
    }
  
}
