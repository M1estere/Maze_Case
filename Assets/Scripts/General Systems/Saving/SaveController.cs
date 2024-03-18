using UnityEngine;

public class SaveController : MonoBehaviour
{
    public static readonly string MAZE_TRANSFORM_SAVE_NAME = "_mazeTransform";
    public static readonly string PLAYER_TRANSFORM_SAVE_NAME = "_playerTransform";
    public static readonly string REMAINING_TIME_SAVE_NAME = "_remainingTime";

    public static readonly string UNLOCKED_STATUS_SAVE_NAME = "_unlocked";
    public static readonly string RECORD_TIME_SAVE_NAME = "_recordTime";

    public static SaveController Instance { get; private set; }

    [SerializeField] private Transform _cubeMaze;
    [SerializeField] private Transform _playerSphere;
    [Space(5)]

    [SerializeField] private Countdown _countdown;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    public void Save()
    {
        ES3.Save(LevelController.Instance.GetLevelName() + MAZE_TRANSFORM_SAVE_NAME, _cubeMaze);
        ES3.Save(LevelController.Instance.GetLevelName() + PLAYER_TRANSFORM_SAVE_NAME, _playerSphere);

        ES3.Save(LevelController.Instance.GetLevelName() + REMAINING_TIME_SAVE_NAME, _countdown);
    }

    public void Load()
    {
        ES3.LoadInto(LevelController.Instance.GetLevelName() + MAZE_TRANSFORM_SAVE_NAME, _cubeMaze);
        ES3.LoadInto(LevelController.Instance.GetLevelName() + PLAYER_TRANSFORM_SAVE_NAME, _playerSphere);

        ES3.LoadInto(LevelController.Instance.GetLevelName() + REMAINING_TIME_SAVE_NAME, _countdown);
    }

    public void SaveRecordTime()
    {
        string savePrefName = LevelController.Instance.GetLevelName() + RECORD_TIME_SAVE_NAME;
        float wastedTime = LevelController.Instance.CurrentLevel.ExpectedTime - _countdown.GetRemainingTime();

        if (ES3.KeyExists(savePrefName))
        {
            if (ES3.Load<float>(savePrefName) > wastedTime)
            {
                ES3.Save(savePrefName, wastedTime);
            }
        } else
        {
            ES3.Save(savePrefName, wastedTime);
        }
    }

    public float GetRecordTime(string sceneName)
    {
        string savePrefName = sceneName + RECORD_TIME_SAVE_NAME;
        if (ES3.KeyExists(savePrefName))
        {
            return ES3.Load<float>(savePrefName);
        }

        return 0;
    }

    public void SaveKey(string name) => ES3.Save(name, true);

    public float GetValue(string key)
    {
        if (HasKey(key))
            return ES3.Load<float>(key);

        return 0;
    }

    public void SaveCompleted() =>
        ES3.Save(LevelController.Instance.GetLevelName() + UNLOCKED_STATUS_SAVE_NAME, true);

    public bool IsLevelUnlocked(string levelName) => HasKey(levelName + UNLOCKED_STATUS_SAVE_NAME);

    public bool HasKey(string key) => ES3.KeyExists(key);

    public bool HasAllLevelKeys()
    {
        return ES3.KeyExists(LevelController.Instance.GetLevelName() + MAZE_TRANSFORM_SAVE_NAME) || 
               ES3.KeyExists(LevelController.Instance.GetLevelName() + PLAYER_TRANSFORM_SAVE_NAME) || 
               ES3.KeyExists(LevelController.Instance.GetLevelName() + REMAINING_TIME_SAVE_NAME);
    }

    public bool HasAllLevelKeys(string name)
    {
        return ES3.KeyExists(name + MAZE_TRANSFORM_SAVE_NAME) ||
               ES3.KeyExists(name + PLAYER_TRANSFORM_SAVE_NAME) ||
               ES3.KeyExists(name + REMAINING_TIME_SAVE_NAME);
    }

    public void DeleteKey(string key) => ES3.DeleteKey(key);

    public void DeleteAllKeys()
    {
        ES3.DeleteKey(LevelController.Instance.GetLevelName() + MAZE_TRANSFORM_SAVE_NAME);
        ES3.DeleteKey(LevelController.Instance.GetLevelName() + PLAYER_TRANSFORM_SAVE_NAME);

        ES3.DeleteKey(LevelController.Instance.GetLevelName() + REMAINING_TIME_SAVE_NAME);
    }
}
