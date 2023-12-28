using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class renwu : MonoBehaviour
{
    public GameObject UIRed; //  背包
    public GameObject UIBlue;  //地图
    public GameObject UIYellow;   //设置
    public GameObject UIGreen;  //人物界面
    public GameObject play;  //进入游戏
    public GameObject StartMove;//启动动画
    public GameObject music;
    private VideoPlayer videoPlayer;
    private bool movie=false;
    void Start()
    {
        Status = UIStatus.Green;//在start方法中给属性赋值Green，让游戏一开始就显示主UI界面
    }
    void Update()
    {

    }
    public enum UIStatus//定义枚举，列举UI显示的情况
    {
        Red,
        Blue,
        Yellow,
        Green
    }
    private UIStatus uistatus;//创建枚举变量
    private UIStatus Status//定义属性给枚举变量赋值
    {
        get
        {
            return uistatus;
        }
        set
        {
            uistatus = value;
            UpdateUI();//在给枚举变量赋值后调用UI显示方法，控制UI的显示
        }
    }
    public void UpdateUI()//定义UI显示的方法，通过枚举变量的值来判断
    {
        UIRed.SetActive(uistatus == UIStatus.Red);
        UIBlue.SetActive(uistatus == UIStatus.Blue);
        UIYellow.SetActive(uistatus == UIStatus.Yellow);
    }
    public void Red()//显示背包的方法
    {
        Status = UIStatus.Red;
    }
    public void Blue()//显示地图的方法
    {
        Status = UIStatus.Blue;
    }
    public void Yellow()//显示设置的方法
    {
        Status = UIStatus.Yellow;
    }
    public void end()//退出游戏
    {
     //   UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void Exit() //返回人物选择界面
    {
        Status = UIStatus.Green;
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
