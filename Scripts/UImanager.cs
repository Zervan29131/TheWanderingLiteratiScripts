using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class UImanager : MonoBehaviour
{
    //定义三个GameObject类用来表示UI功能
    public GameObject UIRed;
    public GameObject UIBlue;
    public GameObject UIYellow;
    public GameObject UIGreen;
    public GameObject UIAgree;
    public GameObject bag;
    public GameObject map;
    public GameObject play;  //进入游戏
    public GameObject StartMove;//启动动画
    public GameObject music;
  
    private VideoPlayer videoPlayer;
    private bool movie = false;
    private bool agree = false;

    void Start()
    {
        
    }
    //多UI选一
    ////void Update()
    ////{

    ////}
    ////public enum UIStatus//定义枚举，列举UI显示的情况
    ////{
    ////    Red,
    ////    Yellow,
    ////    Green
    ////}
    ////private UIStatus uistatus;//创建枚举变量
    ////private UIStatus Status//定义属性给枚举变量赋值
    ////{
    ////    get
    ////    {
    ////        return uistatus;
    ////    }
    ////    set
    ////    {
    ////        uistatus = value;
    ////        UpdateUI();//在给枚举变量赋值后调用UI显示方法，控制UI的显示
    ////    }
    ////}
    ////public void UpdateUI()//定义UI显示的方法，通过枚举变量的值来判断
    ////{
    ////    UIRed.SetActive(uistatus == UIStatus.Red);
    ////    UIYellow.SetActive(uistatus == UIStatus.Yellow);
    ////}
    public void Red()    //进入人物选择界面
    {
        if(agree)
        {
            UIRed.SetActive(true);
        }

    }
    public void xRed()   //关闭人物选择界面
    {
        UIRed.SetActive(false);
    }
    public void oBag()   //打开背包界面
    {
        bag.SetActive(true);
    }
    public void xBag()   //关闭背包界面
    {
        bag.SetActive(false);
    }
    public void omap()   //打开地图界面
    {
        map.SetActive(true);
    }
    public void xmap()   //关闭地图界面
    {
        map.SetActive(false);
    }
    public void Blue()   //显示设置
    {
        UIBlue.SetActive(true);
    }
    public void Yellow()//退出游戏
    {
        Application.Quit();
    }
    public void Agree()  //判定是否同意用户协议
    {
         UIAgree.SetActive(true);
         agree = true;    
    }
    public void disagree()   //不同意用户协议
    {
        UIAgree.SetActive(false);
        agree = false;
    }
    public void Exit()   //关闭设置界面
    {
        UIBlue.SetActive(false);
    }


    private void VideoPlayer_loopPointReached(VideoPlayer source)
    {
        if (StartMove != null)
        {
            StartMove.SetActive(false);
            GameObject.Destroy(StartMove);
            StartMove = null;
            if (movie)
            {
                music.SetActive(true);
                SceneManager.LoadScene("map1");
            }
        }

    }

    public void start()//显示红色UI的方法
    {
        if (StartMove != null)//播放启动动画
        {
            videoPlayer = StartMove.GetComponent<VideoPlayer>();
            StartMove.SetActive(true);//默认对象关闭
            videoPlayer.loopPointReached += VideoPlayer_loopPointReached;//添加播放结束事件
            StartMove.transform.SetAsLastSibling();
            music.SetActive(false);
            videoPlayer.Play();//播放视频

            movie = true;
        }
    }
}
