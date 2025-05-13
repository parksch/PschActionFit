using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class StageEditorManager //UI
{
    [SerializeField] Text currentSelect;
    [SerializeField] InputField xInput;
    [SerializeField] InputField yInput;
    [SerializeField] InputField stageInput;
    [SerializeField] RectTransform jsonContent;
    [SerializeField] RectTransform colorContent;
    [SerializeField] List<ColorButton> colorButtons;
    [SerializeField] List<JsonLoad> loadObjects;
    [SerializeField] ColorButton colorButtonPrefab;
    [SerializeField] JsonLoad jsonLoadPrefab;

    public void InitUI()
    {
        var jsonFiles = Resources.LoadAll<TextAsset>("Data/Json");

        for (int i = 0; i < jsonFiles.Length; i++)
        {
            if (i == 0)
            {
                jsonLoadPrefab.Set(jsonFiles[i]);
                loadObjects.Add(jsonLoadPrefab);
            }
            else
            {
                JsonLoad copy = Instantiate(jsonLoadPrefab, jsonContent);
                copy.Set(jsonFiles[i]);
                loadObjects.Add(copy);
            }
        }

        for (int i = 0;i <= (int)ColorType.Green; i++)
        {
            if (i == 0)
            {
                colorButtonPrefab.Set((ColorType)i);
                colorButtons.Add(colorButtonPrefab);
            }
            else
            {
                ColorButton copy = Instantiate(colorButtonPrefab, colorContent);
                copy.Set((ColorType)i);
                colorButtons.Add(copy);
            }
        }

        currentSelect.text = "Select : " + currentColor.ToString();
    }

    public void OnClickCreateButton()
    {
        CreateGrid();
    }

    public void OnClickColorButton(ColorButton colorButton)
    {
        currentColor = colorButton.ColorType;
        currentSelect.text = "Select : " + currentColor.ToString();
    }

    public void OnClickLoadJson(JsonLoad load)
    {
        StageJsonWrapper wrapper = JsonUtility.FromJson<StageJsonWrapper>(load.Json.text);
        StageJsonData stageJson = wrapper.Stage;
        int x = 0, y = 0;
        
        foreach (var item in stageJson.boardBlocks)
        {
            if (x < item.x + 1)
            {
                x = item.x + 1;
            }

            if (y < item.y + 1)
            {
                y = item.y + 1;
            }
        }

        stageInput.text = stageJson.stageIndex.ToString();
        xInput.text = x.ToString();
        yInput.text = y.ToString();

        LoadObjects(stageJson);
    }
}
