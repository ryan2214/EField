using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{   
    private bool isBuildMenuOn = false;
    private CanvasGroup trans;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<CanvasGroup>();
        trans.alpha = 0;
        trans.interactable = false;
        trans.blocksRaycasts = false;
        isBuildMenuOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab)){
            if(!isBuildMenuOn){
                trans.alpha = 0.9f;
                trans.interactable = true;
                trans.blocksRaycasts = true;
                isBuildMenuOn = true;
            }else{
                trans.alpha = 0;
                trans.interactable = false;
                trans.blocksRaycasts = false;
                isBuildMenuOn = false;
            }
        }
    }
}
