using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Talkable : MonoBehaviour
{
//    [SerializeField] private bool  OnCollisionEnter
   [SerializeField] private bool isEntered;

    public VideoPlayer needVideo;
    public bool isFinish = false;
    [TextArea(1, 10)]
    public string[] lines;//真正的文字对话内容会放在每个talkable脚本内部，自定义的文字内容，储存在集合lines中
    // [SerializeField] public bool hasName;//Default Value is false

    // public GameObject talkIcon;//用来提示玩家可以对话的UI交互

    // public Questable questable;//可说话的NPC中，含有任务

    // public QuestTarget questTarget;

    // [TextArea(1,4)]
    // public string[] congatLines;//完成任务之后NPC说的祝福语句之类的话

    // //完成任务之后，能够说一些别的话，而不是重复介绍任务
    // [TextArea(1, 4)]
    // public string[] completeLines;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isEntered = true;
            // talkIcon.SetActive(true);

            // DialogueManager.instance.currentQuestable = questable;
            // DialogueManager.instance.questTarget = questTarget;
            // DialogueManager.instance.talkable = this;

            // StartCoroutine(FadeIn());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = false;

            //StartCoroutine(FadeOut());//ERROR
            // DialogueManager.instance.currentQuestable = null;
            // talkIcon.GetComponent<CanvasGroup>().alpha = 0;
            // talkIcon.SetActive(false);
        }
    }

// //使函数在update仅触发执行一次
// private bool condition = false;
// void Update(){
//     if (!condition){
//         //想要执行的方法  
//         if(isEntered &&  DialogueManager.instance.dialogueBox.activeInHierarchy == false)//按下空格健使得对话窗口出现
//         {
//             DialogueManager.instance.ShowDialogue(lines);
//         } 
//         condition = true;
// }
// }




    private void Update()
    {
                // if(isEntered )//按下空格健使得对话窗口出现
        if(isEntered&&!isFinish && DialogueManager.instance.dialogueBox.activeInHierarchy == false)//按下空格健使得对话窗口出现
        {
            // if(questable==null)
            // {
 DialogueManager.instance.ShowDialogue(lines,this);
            isFinish = true;
               // DialogueManager.instance.ShowDialogue(lines, hasName);
               // }
               // else
               // {
               //     if(questable.quest.questState==Quest.QuestState.Completed)
               //     {
               //         DialogueManager.instance.ShowDialogue(completeLines, hasName);
               //     }
               //     else
               //     {
               //         DialogueManager.instance.ShowDialogue(lines, hasName);
               //     }
               // }

        }
    }

    // IEnumerator FadeIn()
    // {
    //     talkIcon.GetComponent<CanvasGroup>().alpha = 0;
    //     while (talkIcon.GetComponent<CanvasGroup>().alpha < 1)
    //     {
    //         talkIcon.GetComponent<CanvasGroup>().alpha += 0.02f;
    //         yield return null;
    //     }
    // }

    // //ERROR 这个会有一个问题，就是当Alpha的值还不是0的时候，人物已经出范围了
    // //SOLVED 所以暂时改成了「瞬间消失」
    // //IEnumerator FadeOut()
    // //{
    // //    while (talkIcon.GetComponent<CanvasGroup>().alpha > 0)
    // //    {
    // //        talkIcon.GetComponent<CanvasGroup>().alpha -= 0.03f;
    // //        yield return null;
    // //    }
    // //    talkIcon.SetActive(false);
    // //}

}
