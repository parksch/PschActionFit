using UnityEngine;
using UnityEngine.UI;

public class JsonLoad : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] TextAsset text;

    public TextAsset Json => text;

    public void Set(TextAsset _text)
    {
        title.text = _text.name;
        text = _text;
    }
}
