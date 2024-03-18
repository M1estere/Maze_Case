using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance { get; private set; }

    [SerializeField] private LevelsConfig _levelsConfig;

    [field: SerializeField]
    public int LevelIndex { get; private set; }

    public Level CurrentLevel { get; private set; }

    public bool LevelStarted { get; set; } = false;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;

        CurrentLevel = _levelsConfig.Levels[LevelIndex];
    }

    private void Start()
    {
        if (LevelHasSaves())
            SaveController.Instance.Load();
    }

    public bool LevelHasSaves() => SaveController.Instance.HasAllLevelKeys();

    public bool NextLevelExists() => SceneUtility.GetBuildIndexByScenePath($"Level {LevelIndex + 2}") != -1;

    public string NextLevelName()
    {
        if (NextLevelExists())
            return $"Level {LevelIndex + 2}";

        return "";
    }

    public void NextLevel()
    {
        string nextLevelName = $"Level {LevelIndex + 2}";
        if (NextLevelExists())
        {
            UnStopTime();
            SceneManager.LoadScene(nextLevelName);
        } else
        {
            Debug.LogError(nextLevelName + " doesn't exist!");
        }
    }

    public void RestartLevel()
    {
        UnStopTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenScene(string name)
    {
        UnStopTime();
        SceneManager.LoadScene(name);
    }

    public void OpenScene(int index)
    {
        UnStopTime();
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StopTime() => Time.timeScale = 0;

    public void UnStopTime() => Time.timeScale = 1;

    public string GetLevelName() => $"Level {LevelIndex + 1}";
}