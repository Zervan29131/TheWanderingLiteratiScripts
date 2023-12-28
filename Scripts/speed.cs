 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class speed : MonoBehaviour
{
    public GameObject yes;
    public GameObject no;
    public VideoPlayer videoplayer;

    // Start is called before the first frame update
    void Start()
    {
        Status = UIStatus.no;
        videoplayer.playbackSpeed = 2f;
    }
    public enum UIStatus//定义枚举，列举UI显示的情况
    {
       yes,
       no
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
        yes.SetActive(uistatus == UIStatus.yes);
        no.SetActive(uistatus == UIStatus.no);
    }
    public void YES()//显示蓝色UI的方法
    {
        Status = UIStatus.yes;
        videoplayer.playbackSpeed = 5f;
    }
    public void NO()//显示蓝色UI的方法
    {
        Status = UIStatus.no;
        videoplayer.playbackSpeed = 2f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
