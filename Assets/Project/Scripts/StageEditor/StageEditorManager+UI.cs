using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class StageEditorManager //UI
{
    [SerializeField] InputField xInput;
    [SerializeField] InputField yInput;
    [SerializeField] InputField stageInput;
    [SerializeField] RectTransform content;
    [SerializeField] List<JsonLoad> loadObjects;
    [SerializeField] JsonLoad prefab;

    public void InitUI()
    {
        var jsonFiles = Resources.LoadAll<TextAsset>("Data/Json");

        for (int i = 0; i < jsonFiles.Length; i++)
        {
            if (i == 0)
            {
                prefab.Set(jsonFiles[i]);
                loadObjects.Add(prefab);
            }
            else
            {
                JsonLoad copy = Instantiate(prefab, content);
                copy.Set(jsonFiles[i]);
                loadObjects.Add(copy);
            }
        }
    }

    public void OnClickCreateButton()
    {
        CreateGrid();
    }

    public void OnClickSaveJson(JsonLoad load)
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
