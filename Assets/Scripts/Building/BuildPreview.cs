using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPreview : MonoBehaviour
{
   const float TRANSPARENT_AMOUNT = 0.5f;
 
   public void ToggleTransparency (bool transparent)
   {
        float desiredTransparency = transparent ? TRANSPARENT_AMOUNT : 1.0f;
        // Find all the renderers on the object, including the children
        var renderers = GetComponentsInChildren<Renderer>(true);
        foreach (var renderer in renderers)
        {
        var color = renderer.material.color;
        renderer.material.color = new Color(color.r, color.g, color.b, desiredTransparency);
        }
   }

}
