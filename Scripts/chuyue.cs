using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class chuyue : MonoBehaviour
{
    public GameObject StartMove;//启动动画
    public GameObject music;
    public GameObject dizi;

    private VideoPlayer videoPlayer;

    private bool movie = false;
    private void OnTriggerEnter(Collider collider)
    {
        start();
        dizi.SetActive(true);
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
            }
        }

    }

    public void start()
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
