using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Panel : MonoBehaviour, IPointerDownHandler
{
    private bool isFade = false;
    [SerializeField] private CanvasGroup myUIGroup;
    //[SerializeField] private fadeIn = false;
    [SerializeField] private bool fadeOut = false;
    //public void ShowUI(){
    //    fadeIn = true;
    //}
    public void HideUI(){
        fadeOut = true;
    }
	public void OnPointerDown(PointerEventData pointerEventData)
    {
        if(!isFade){
            HideUI();
            isFade = true;
        }
    }
    private void FixedUpdate(){
        if(fadeOut){
            if(myUIGroup.alpha>0){
                myUIGroup.alpha -= 0.02f;
                if(myUIGroup.alpha == 0){
                    fadeOut = false;
                }
            }
        }
    }
}
