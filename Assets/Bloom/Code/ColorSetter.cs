using UnityEngine;

public class ColorSetter : MonoBehaviour
{
    Renderer rend;

    public void SetColor(float r, float g, float b)
    {
        Color cloneColor = new Color(r,g,b,1); // takes individually randomized colors and applies them to each new instantiated flower
        
        GetComponent<Renderer>().material.color = cloneColor; // changes the color
    }
}
