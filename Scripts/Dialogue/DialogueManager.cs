using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;//MARKER SINGLETON PATTERN//单例模式是通过关键字static和其他语句只生成对象的一个实例

    public GameObject dialogueBox;//Display or Hide 展示或隐藏对话窗口
    public Text dialogueText, nameText;
    public Talkable curTalkable;
    [TextArea(1, 3)]//保证输入的文字不会显示成默认的一行
    public string[] dialogueLines;//声明一个string类型的数组，来表示对话的内容
    [SerializeField] private int currentLine;//声明一个对象currentLine用来实时追踪当前对话窗口正在进行数组中哪一行哪一个元素的文字内容输出


    public GameObject mainMap;
    // private bool isScrolling;//Default value is false
    // [SerializeField] private float textSpeed;

    // public QuestTarget questTarget;

    // public Talkable talkable;

    private void Awake()//单例模式
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
       // dialogueText.text = dialogueLines[currentLine];
    }

    private void Update()
    {
        if(dialogueBox.activeInHierarchy)//检测整个对话窗口在hierarchy的显示状态是否可见，只有对话窗口可见的时候，才能一句话接一句话跳转显示文字
        {
          

            if (Input.GetMouseButtonUp(0) && dialogueText.text == dialogueLines[currentLine])
            {
              
                if (isClick)
                {
                    isClick = false;
                    return;
                }

                //             if(isScrolling == false)
                //             {
                currentLine++;

                    if (currentLine < dialogueLines.Length&& currentLine!=dialogueLines.Length/2)//常见报错只有数组小于当前行数的时候才能显示这段话
                    {
                        CheckName();
                        dialogueText.text = dialogueLines[currentLine];//REPLACED line by line Show
    //                     StartCoroutine(ScrollingText());//Letter by Letter Show
                    }
    //                 else
    //                 {
    //                     if(CheckQuestIsComplete()&&currentQuestable.isFinished==false)
    //                     {
    //                         ShowDialogue(talkable.congatLines, talkable.hasName);
    //                         currentQuestable.isFinished = true;
    //                     }
                        else
                        {
                    if (curTalkable.needVideo != null) {
                        curTalkable.needVideo.gameObject.SetActive(true);
                        mainMap.SetActive(true);
                            curTalkable.needVideo.Play();
                    }

                            dialogueBox.SetActive(false);//Box HIDE MARKER END Dialogue对话长度不断累加，等于数组的长度，再次按下左键，窗口隐藏不可见
                                        }}}}

    //                         PlayerMovement.instance.isTalking = false;
    //                         if (currentQuestable == null)
    //                         {
    //                             Debug.Log("There is no quest in this person");
    //                         }
    //                         else
    //                         {
    //                             currentQuestable.DelegateQuest();
    //                             QuestManager.instance.UpdateQuestList();
    //                             if(CheckQuestIsComplete()&&currentQuestable.isFinished==false)
    //                             {
    //                                 ShowDialogue(talkable.congatLines, talkable.hasName);
    //                                 currentQuestable.isFinished = true;
    //                             }
    //                         }
    //                         //对话任务判断是否完成
    //                         if (questTarget != null)
    //                         {
    //                             for (int i = 0; i < Player.instance.questList.Count; i++)
    //                             {
    //                                 if (Player.instance.questList[i].questName == questTarget.questName)
    //                                 {
    //                                     questTarget.hasTalked = true;
    //                                     questTarget.QuestComplete();
    //                                 }
    //                             }
    //                         }
    //                         else
    //                         {
    //                             return;
    //                         }
    //                     }
    //                     #region
    //                     //dialogueBox.SetActive(false);//Box HIDE MARKER END Dialogue
    //                     //PlayerMovement.instance.isTalking = false;
    //                     //if (currentQuestable == null)
    //                     //{
    //                     //    Debug.Log("There is no quest in this person");
    //                     //}
    //                     //else
    //                     //{
    //                     //    currentQuestable.DelegateQuest();
    //                     //    QuestManager.instance.UpdateQuestList();
    //                     //}
    //                     //if(questTarget!=null)
    //                     //{
    //                     //    questTarget.hasTalked = true;
    //                     //    questTarget.QuestComplete();
    //                     //}
    //                     //else
    //                     //{
    //                     //    return;
    //                     //}
    //                     #endregion
    //                     //FindObjectOfType<PlayerMovement>().canMove = true;//REPLACED
    //                     //FindObjectOfType<PlayerMovement>().isTalking = false;//REPLACED
    //                 }
    //             }
    //         }
    //     }
    // }

    public bool isClick = false;
    public void TranslateDialogue() {
        isClick = true;
        if (currentLine < dialogueLines.Length / 2)
        {
            currentLine += dialogueLines.Length / 2;
            currentLine-=1;
            CheckName();
            dialogueText.text = dialogueLines[currentLine];

        }
        else {
            currentLine -= dialogueLines.Length / 2;
            currentLine -= 1;
            CheckName();
            dialogueText.text = dialogueLines[currentLine];

        }
    
    
    }

    public void ShowDialogue(string[] _newLines, Talkable curTalkable=null)//, bool _hasName)//进入范围内后按下空格键之后的所有操作，方法传递了一个参数表示了不同人物不同npc的对话内容
    {
        mainMap.SetActive(true);
        this.curTalkable = curTalkable;
        dialogueLines = _newLines;//将该参数赋值给dialoguelines
        currentLine = 0;//每次开始新的对话，都是从对话的第一句开始的

        CheckName();
    //     SetTextAlign(_hasName);

        dialogueText.text = dialogueLines[currentLine];//REPLACED LIne by line show 
    //     StartCoroutine(ScrollingText());

        dialogueBox.SetActive(true);//将对话的窗口显示出来

    //     //MARKER if hasName is True, nameText display. nameText.gameObject.SetActive(true);
    //     //MARKER if hasName is False, nameText Hide. nameText.gameObject.SetActive(false);
    //     nameText.gameObject.SetActive(_hasName);

        // FindObjectOfType<PlayerMovement>().canMove = false;//REPLACED CANNOT MOVE NOW
    //     //FindObjectOfType<PlayerMovement>().isTalking = true;//REPLACED
    //     PlayerMovement.instance.isTalking = true;
    }

    // private void SetTextAlign(bool _hasName)
    // {
    //     if (_hasName)
    //         dialogueText.alignment = (UnityEngine.TextAnchor)TextAlignment.Left;
    //     else
    //         dialogueText.alignment = (UnityEngine.TextAnchor)TextAlignment.Center;
    // }

    private void CheckName()
    {
        if(dialogueLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("n-", "");//Remove "n-"将n-开头的内容显示在了ui画布nametext对象的text属性中
            currentLine++;
        }
    }

    // private IEnumerator ScrollingText()
    // {
    //     isScrolling = true;
    //     dialogueText.text = "";

    //     foreach(char letter in dialogueLines[currentLine].ToCharArray())
    //     {
    //         dialogueText.text += letter;//HELLO => H->E->L->L->O//MARKER Letter by Letter Show
    //         yield return new WaitForSeconds(textSpeed);
    //     }

    //     isScrolling = false;
    // }

    // //和委派任务的NPC完成对话之后，调用这个方法,判断任务是否已经完成了
    // public bool CheckQuestIsComplete()
    // {
    //     if(currentQuestable==null)
    //     {
    //         return false;
    //     }
    //     for (int i = 0; i < Player.instance.questList.Count; i++)
    //     {
    //         if(currentQuestable.quest.questName==Player.instance.questList[i].questName
    //             &&Player.instance.questList[i].questState==Quest.QuestState.Completed)
    //         {
    //             currentQuestable.quest.questState = Quest.QuestState.Completed;
    //             return true;
    //         }
    //     }
    //     return false;
    // }

}
