using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject UIbag;
    public GameObject UImain;
    public GameObject UIshezhi;
    public GameObject bag_exit;
    // Start is called before the first frame update
    void Start()
    {
        Status = UIStatus.UImain;//在start方法中给属性赋值Green，让游戏一开始就显示主UI界面
    }
    public enum UIStatus//定义枚举，列举UI显示的情况
    {
        UImain,
        UIbag,
        UIshezhi
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
        UIbag.SetActive(uistatus == UIStatus.UIbag);
        UIshezhi.SetActive(uistatus == UIStatus.UIshezhi);
    }
    public void bag()//显示蓝色UI的方法
    {
        Status = UIStatus.UIbag;
    }
    public void shezhi()
    {
        Status = UIStatus.UIshezhi;
    }
    public void exit()
    {
        Status = UIStatus.UImain;
    }
    public void gameexit()
    {
        //        Status = UIStatus.Yellow;
       // UnityEditor.EditorApplication.isPlaying = false;
              Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
