using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuildingPositon : MonoBehaviour
{
    //public Vector2 originalPositon;//原始坐标
    public double positonX;//原始坐标X
    public double positonY;//原始坐标Y
    public double d_positionX,d_positionY;
    public string stringPositionX;
    public string stringPositionY;

    public float x;
    public float y;
   

    public void OnEnable()
    {
        /*positonX = transform.position.x;
        positonY = transform.position.y;
        stringPositionX = Convert.ToDouble(positonX).ToString("0");
        stringPositionY = Convert.ToDouble(positonY).ToString("0");
        d_positionX = Convert.ToDouble(stringPositionX);
        d_positionY = Convert.ToDouble(stringPositionY);
        transform.position = new Vector2((float)d_positionX , (float)d_positionY);*/
    }
    public void Update()
    {
        positonX = transform.position.x;
        positonY = transform.position.y;
        stringPositionX = Convert.ToDouble(positonX).ToString("0.0");
        stringPositionY = Convert.ToDouble(positonY).ToString("0.0");
        d_positionX = Convert.ToDouble(stringPositionX);
        d_positionY = Convert.ToDouble(stringPositionY);
        x = (float)d_positionX;
        y = (float)d_positionY;
        transform.position = new Vector2(x,y);
    }

}
