using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{
    public static BagManager instance;//MARKER SINGLETON PATTERN//����ģʽ��ͨ���ؼ���static���������ֻ���ɶ����һ��ʵ��
    private void Awake()//����ģʽ
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    public List<int> ItemId = new List<int>();

    public Text itemInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Image[] allImages;
    public Sprite[] allSprite;
    public void AddItem(int id)
    {
        ItemId.Add(id);
        StartCoroutine(showGetItem(id));
        showItem();
    }
    public void showItem()
    {

        for (var i = 0; i < ItemId.Count; i++)
        {
            allImages[i].sprite = allSprite[ItemId[i]];
            allImages[i].gameObject.SetActive(true);
            var index = i;
            allImages[i].GetComponent<Button>().onClick.AddListener(() =>
            {
                showInfo(index);
            });
        }


    }

    public Image itemImage;
    public IEnumerator showGetItem(int id) {
        itemInfo.transform.parent.gameObject.SetActive(true);

        itemImage.sprite = allSprite[id];
        switch (id) {
            case 0:
                itemInfo.text = "�ѻ�ȡ��";
                break;
            case 1:
                itemInfo.text = "�ѻ�ȡ����";
                break;
            case 2:
                itemInfo.text = "�ѻ�ȡ¶ˮ��ҶƬ";
                break;
            case 3:
                itemInfo.text = "�ѻ�ȡ��Ө�����";
                break;
            case 4:
                itemInfo.text = "�ѻ�ȡ�峺���¹�";
                break;
            case 5:
                itemInfo.text = "�ѻ�ȡ";
                break;


        }
        yield return new WaitForSeconds(3f);
        itemInfo.transform.parent.gameObject.SetActive(false);

    }

    public void showInfo(int index) { 
    
    
    }
}
