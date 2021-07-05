using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ondrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public GameObject target;
    Vector2 screenPosition;//将物体从世界坐标转换为屏幕坐标
    Vector2 mousePositionOnScreen;//获取到点击屏幕的屏幕坐标
    Vector2 mousePositionInWorld;//将点击屏幕的屏幕坐标转换为世界坐标
    Vector2 mouseOriginalPositionOnScreen;
    Vector2 mouseOriginalPositionInWorld;
    public float factor;


    public Vector2 originalPosition;
    public Vector2 targetOriginalPosition;
   public void OnBeginDrag(PointerEventData eventData)
   {
    targetOriginalPosition = target.transform.position;   
    mouseOriginalPositionOnScreen = Input.mousePosition;
    //将相机中的坐标转化为世界坐标
    //mouseOriginalPositionInWorld = Camera.main.ScreenToWorldPoint(mouseOriginalPositionOnScreen);
    //transform.position = mousePositionInWorld;
       //target.transform.position = eventData.position;

   }
   public void OnDrag(PointerEventData eventData)
   {
    //获取鼠标在相机中（世界中）的位置，转换为屏幕坐标；
    //screenPosition = Camera.main.WorldToScreenPoint(transform.position);
    //获取鼠标在场景中坐标
    mousePositionOnScreen = Input.mousePosition;
    //将相机中的坐标转化为世界坐标
    //mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
  
    target.transform.position = (mouseOriginalPositionOnScreen - mousePositionOnScreen) * factor + targetOriginalPosition;
    //transform.position = mousePositionInWorld;

   }
   public void OnEndDrag(PointerEventData eventData)
   {
       //targetOriginalPosition = target.transform.position;
       //originalPosition = target.transform.position;
       //target.transform.position = eventData.position;
       //target.transform.position = mousePositionInWorld;

   }
}
