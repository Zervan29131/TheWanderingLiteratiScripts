using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    public VideoPlayer vp;
    public int index = 0;

    public GameObject mainMap;
    public int itemId;

    public GameObject anim;

    public GameObject rawImage;
    void Start()
    {
        rawImage.SetActive(true);
           vp = GetComponent<VideoPlayer>();
        vp.loopPointReached += EndWithVideoPlay;
    }
    public void EndWithVideoPlay(VideoPlayer source)
    {
        RemoveTargetframe();
        //TODO播放完成后事件
    }
    /// <summary>
    ///texture 清除上一帧渲染
    /// </summary>
    private void RemoveTargetframe()
    {
        rawImage.SetActive(false);
        vp.enabled = false;
        switch (index) {
            case 0:
                BagManager.instance.AddItem(2);
                anim.SetActive(true);
              StartCoroutine (showNext());
                break;
            case 1:
                BagManager.instance.AddItem(3);
                StartCoroutine(showNext1());
                break;
            case 2:
                BagManager.instance.AddItem(4);
               
                break;


        }
    }


    public Light light;
    public Talkable talkable;
    public GameObject rain;
    public IEnumerator showNext() {
        var timer = 3f;
        while (timer > 0)
        {
            light.intensity -= 0.3f;
            yield return new WaitForSeconds(0.1f);
            timer -= 0.1f;
        }
        rain.SetActive(true);
        yield return new WaitForSeconds(3f);
        DialogueManager.instance.ShowDialogue(talkable.lines, talkable);
     
    }

    public IEnumerator showNext1()
    {
        var timer = 3f;
        while (timer > 0)
        {
            light.intensity += 0.3f;
            yield return new WaitForSeconds(0.1f);
            timer -= 0.1f;
        }
        rain.SetActive(false);
        yield return new WaitForSeconds(3f);

        DialogueManager.instance.ShowDialogue(talkable.lines, talkable);
       
    }
}
