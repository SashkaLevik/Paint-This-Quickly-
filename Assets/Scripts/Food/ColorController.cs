using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField] protected Tank _tank;
    public List<Color> colors = new List<Color>();

    protected Color _tankColor;

    private Color _redColor = new Color32(255, 0, 0, 255);
    private Color _orangeColor = new Color32(255, 127, 0, 255);
    private Color _yellowColor = new Color32(255, 255, 0, 255);
    private Color _greenColor = new Color32(0, 128, 0, 255);
    private Color _blueColor = new Color32(0, 0, 255, 255);
    private Color _skyColor = new Color32(0, 255, 255, 255);
    private Color _purpleColor = new Color32(128, 0, 128, 255);
    private Color _braunColor = new Color32(128, 78, 32, 255);


    private void Start()
    {
        colors.Add(_redColor);
        colors.Add(_orangeColor);
        colors.Add(_yellowColor);
        colors.Add(_greenColor);
        colors.Add(_blueColor);
        colors.Add(_skyColor);
        colors.Add(_purpleColor);
        colors.Add(_braunColor);
    }

    private void Update()
    {
        _tankColor = _tank.CurrentColor;
    }   

    public bool TryGetColor(Color color)
    {
        bool result = false;
        if (_tankColor == color)
            result = true;
        return result;
    }
}
