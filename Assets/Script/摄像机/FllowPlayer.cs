using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FllowPlayer : MonoBehaviour
{
        [Header("目标抓取（目标设定为大地图，无需更改）")]
        //public Transform target;
        //位置偏移
        private Vector3 offsetPosition;
        //是否开始滑动拉近和拉远视角
        private bool isAdjustDistance= false;
        private Camera camera;
        //是否开始滑动旋转视角
       // private bool isRotating = false;
        [Header("视角大小（可调整）")]
        public float distance = 0;
        public float minDistance = 10;
        public float maxDistance = 30;

        [Header("鼠标滚轮调节速率")]
        public float scrollSpeed = 10;
        //[Header("鼠标左键调节旋转速率")]
        //public float rotateSpeed = 2;
        //[Header("自动旋转速率")]
        //public float autoRotateSpeed = 10;
        private void Start()
        {
            //transform.LookAt(target.position);
            //offsetPosition = transform.localScale - target.position;
            
        }

        private void Update()
        {
            //处理视野的旋转
           // RotateView();
            //处理视野的拉近和拉远效果
            ScrollView();           
        }
        /// <summary>
        /// 视野的拉近和拉远
        /// </summary>
        private void ScrollView()
        {
            
            //向后滑动返回负值 (拉近视野)，向前滑动返回正值(拉远视野)
            //print(Input.GetAxis("Mouse ScrollWheel"));
            //得到距离

            //distance = offsetPosition.magnitude;
            if (Input.GetMouseButtonDown(1))
            {
                isAdjustDistance = true;
            }
            if (Input.GetMouseButtonUp(1))
            {
                isAdjustDistance = false;
            }
            if(isAdjustDistance)
            {
                distance += Input.GetAxis("Mouse Y") * scrollSpeed*Time.deltaTime;         //通过鼠标右键在垂直方向的滑动调节

            }
            
            distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;                 //通过鼠标滚轮调节
            //限制拉近和拉远的距离
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
            //offsetPosition = offsetPosition.normalized * distance;
            //相机的跟随
            transform.position = new Vector3(transform.position.x, transform.position.y, -distance);
            
            
            //transform.localScale = new Vector3(0, 0, 0);
        }
        
    }
