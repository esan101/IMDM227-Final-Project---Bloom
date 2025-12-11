using UnityEngine;

public class ColorSetter : MonoBehaviour
{
    Renderer rend;

    public void SetColor(float r, float g, float b)
    {
        Color cloneColor = new Color(r,g,b,1);
        
        GetComponent<Renderer>().material.color = cloneColor;
    }
}
