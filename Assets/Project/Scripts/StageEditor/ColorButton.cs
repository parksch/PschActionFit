using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] ColorType colorType;

    public ColorType ColorType => colorType;

    public void Set(ColorType value)
    {
        title.text = value.ToString();
        colorType = value;
    }
}
