using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GamePad : MonoBehaviour,IPointerUpHandler,IDragHandler,IPointerDownHandler
{
    public Image padBg;

    public Image controller;

    public Vector2 vector;
    
    // Start is called before the first frame update
    void Start()
    {
        padBg = GetComponentInParent<Image>();
        controller = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float Horizontal()
    {
        if (vector.x!=0)
        {
            return vector.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }
    
    public float Vertical()
    {
        if (vector.y!=0)
        {
            return vector.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
    
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(padBg.rectTransform,eventData.position,eventData.pressEventCamera,out pos))
        {
            pos.x = (pos.x / padBg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / padBg.rectTransform.sizeDelta.y);
            vector = new Vector2(pos.x*2-1,pos.y*2-1);
            vector =(vector.magnitude>1)?vector.normalized:vector;
            
            controller.rectTransform.anchoredPosition = new Vector2( vector.x*(padBg.rectTransform.sizeDelta.x/2),vector.y*(padBg.rectTransform.sizeDelta.y/2));
                
            Debug.Log("OnDrag pos="+pos);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        vector = Vector2.zero;
        Debug.Log("OnPointerUp");
        controller.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
        Debug.Log("OnPointerDown");
    }
}
