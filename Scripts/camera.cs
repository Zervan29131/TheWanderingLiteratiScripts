using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // 模型
    public Transform car_model;
    // 旋转速度
    public static float rotateSpeed = 10f;  //一定要使用static，不然可能变量值读不到
    public static float rotateLerp = 8;
    // 移动速度
    public static float moveSpeed = 2f;//0.5
    public static float moveLerp = 10f;
    // 镜头拉伸速度
    public static float zoomSpeed = 50f;   //速度比例因子//10
    public static float zoomLerp = 4f;     //阻尼系数，有个缓冲作用

    // 计算移动
    private Vector3 position, targetPosition;
    // 计算旋转
    private Quaternion rotation, targetRotation;
    // 计算距离
    private float distance, targetDistance;
    // 默认距离
    private const float default_distance = 5f;


    void Start()
    {
        // 旋转归零
        targetRotation = Quaternion.identity;
        // 初始位置是模型
        targetPosition = car_model.position;
        // 初始镜头拉伸
        targetDistance = default_distance;
    }


    void Update()
    {
        //Debug.Log("camera button ");
        float dx = Input.GetAxis("Mouse X");
        float dy = Input.GetAxis("Mouse Y");

        // 鼠标左键移动
        if (Input.GetMouseButton(0))
        {
            dx *= moveSpeed;
            dy *= moveSpeed;
            targetPosition -= transform.up * dy + transform.right * dx;
        }

        // 鼠标右键旋转
        if (Input.GetMouseButton(1))
        {
            dx *= rotateSpeed;
            dy *= rotateSpeed;
            if (Mathf.Abs(dx) > 0 || Mathf.Abs(dy) > 0)
            {
                // 获取摄像机欧拉角
                Vector3 angles = transform.rotation.eulerAngles;
                // 欧拉角表示按照坐标顺序旋转，比如angles.x=30，表示按x轴旋转30°，dy改变引起x轴的变化
                angles.x = Mathf.Repeat(angles.x + 180f, 360f) - 180f;
                angles.y += dx;
                angles.x -= dy;
                // 计算摄像头旋转
                targetRotation.eulerAngles = new Vector3(angles.x, angles.y, 0);
            }
        }

        // 鼠标滚轮拉伸
        targetDistance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
    }

    private void FixedUpdate()
    {
        rotation = Quaternion.Slerp(rotation, targetRotation, Time.deltaTime * rotateLerp);
        position = Vector3.Lerp(position, targetPosition, Time.deltaTime * moveLerp);
        distance = Mathf.Lerp(distance, targetDistance, Time.deltaTime * zoomLerp);
        // 设置摄像头旋转
        transform.rotation = rotation;
        // 设置摄像头位置
        transform.position = position - rotation * new Vector3(0, 0, distance);
    }

}
