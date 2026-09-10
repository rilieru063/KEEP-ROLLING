using UnityEngine;
using System.IO;

[System.Serializable]
public class StageData
{
    public int width;
    public int height;
    public int[] platform;
}

public class StageLoader : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject startPrefab;
    public Transform platformRoot;

    void Start()
    {
        LoadStage();
    }

    void LoadStage()
    {
        string path = Path.Combine(
            Application.streamingAssetsPath,
            "StageData",
            "Stage01.json"
        );

        string json = File.ReadAllText(path);

        StageData stageData = JsonUtility.FromJson<StageData>(json);

        for (int y = 0; y < stageData.height; y++)
        {
            for (int x = 0; x < stageData.width; x++)
            {
                int value = stageData.platform[y * stageData.width + x];

                Vector3 position = new Vector3(
                    x - (stageData.width - 1) / 2.0f,
                    0,
                    y - (stageData.height - 1) / 2.0f
                );

                if (value == 1)
                {
                    Instantiate(
                        platformPrefab,
                        position,
                        Quaternion.identity,
                        platformRoot
                    );
                }
                else if (value == 2)
                {
                    Instantiate(
                        startPrefab,
                        position,
                        Quaternion.identity,
                        platformRoot
                    );
                }

            }
        }
    }
}