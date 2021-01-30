using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalVarController : MonoBehaviour
{
    static public GlobalVarController gvc;

    //游戏中天数
    private int daysOfGame = 1;

    /**
    //游戏区域/地图区域
    private int mapZone = 0;
    **/

    private void Start()
    {
        gvc = this;
    }

    #region 天数相关

    public int GetDaysOfGame()
    {
        return daysOfGame;
    }

    public void PushDaysBy(int i = 1)
    {
        daysOfGame += i;
        Debug.Log("现在是第" + daysOfGame + "天");
    }

    #endregion
    
    #region 地图区域相关[暂时不用]
    /**
    public int GetZoneIndex()
    {
        return mapZone;
    }

    public void MoveToZone(int i)
    {
        //移动到区域代码块
        mapZone = i;
    }
    **/
    #endregion

}
