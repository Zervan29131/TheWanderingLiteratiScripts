using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    public float walkSpeed;
    //public float runSpeed;
    public float turnSpeed;
    void Update()
    {
        //invControl = GetComponent<InventoryController>();
        if (Input.GetKey(KeyCode.W))
        {
            WalkForward();
        }

        if (Input.GetKey(KeyCode.S))
        {
            WalkBack();
        }

        if (Input.GetKey(KeyCode.A))
        {
            TurnLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            TurnRight();
        }
    }
    void WalkForward()
    {
        transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
    }
    void WalkBack()
    {
        transform.Translate(-Vector3.right * walkSpeed * Time.deltaTime);
    }

    void TurnLeft()
    {
        transform.Rotate(Vector3.down * turnSpeed * Time.deltaTime);
    }
    void TurnRight()
    {
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
    }

}
//BUG:对话时人物可以移动