using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLaunch : MonoBehaviour
{
    private void Awake()
    {
        //初始化游戏框架：资源管理 声音管理 网络管理等等

        this.gameObject.AddComponent<GameApp>();

        this.GameStart();
    }
    public void GameStart()
    {
        //检查资源更新
        //end

        //进入游戏
        this.gameObject.GetComponent<GameApp>().EnterGame();    
        //end
    }
}

