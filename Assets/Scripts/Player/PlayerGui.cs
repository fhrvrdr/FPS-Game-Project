using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGui : MonoBehaviour
{
    [SerializeField]
    Texture2D _crosshair;

     void OnGUI()
    {
        float x = (Screen.width - _crosshair.width) / 2;
        float y = (Screen.height - _crosshair.height) / 2;
        GUI.DrawTexture(new Rect(x, y, _crosshair.width, _crosshair.height), _crosshair);
    } 
}
