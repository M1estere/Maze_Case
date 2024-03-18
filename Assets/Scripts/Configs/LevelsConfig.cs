using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "Levels Config", menuName = "Config/Levels Config", order = 1)]
internal class LevelsConfig : ScriptableObject
{
    [field: SerializeField]
    public List<Level> Levels { get; private set; } = new ();

    public void Initialization()
    {
        for (int i = 0; i < Levels.Count; i++)
            Levels[i].LevelCreated(i + 1);
    }
}

[System.Serializable]
public class Level
{
    [field: SerializeField]
    public Sprite LevelPreview { get; private set; }

    [field: SerializeField]
    public float ExpectedTime { get; private set; }

    public bool Locked { get; private set; } = true;

    public float RecordTime { get; private set; }

    public void LevelCreated(int levelIndex)
    {
        string levelName = $"Level {levelIndex}";
        if (levelIndex == 1) Locked = false;
        else Locked = !SaveController.Instance.IsLevelUnlocked(levelName);

        RecordTime = SaveController.Instance.GetRecordTime(levelName);
    }
}