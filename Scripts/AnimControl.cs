using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(showAnima());
    }
    public GameObject Npc;
    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator showAnima()
    {
        switch (index) {

            case 0:
               
                yield return new WaitForSeconds(2f);
                Npc.SetActive(false);
                yield return new WaitForSeconds(1f);
                gameObject.SetActive(false);
                break;
        }
        yield break;
    }
}
