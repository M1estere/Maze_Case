using UnityEngine;

public class FinishLevelController : MonoBehaviour 
{
    [SerializeField] private GameObject _finishScreen;
    [SerializeField] private GameObject _loseScreen;
    [Space(5)]

    [SerializeField] private GameObject _nextLevelButton;

    private void Start() => 
        _nextLevelButton.SetActive(LevelController.Instance.NextLevelExists());

    public void DisplayFinish()
    {
        SaveController.Instance.SaveKey(LevelController.Instance.NextLevelName() + "_unlocked");
        SaveController.Instance.SaveRecordTime();

        _finishScreen.SetActive(true);
        LevelController.Instance.StopTime();
    }

    public void DisplayLoseScreen()
    {
        _loseScreen.SetActive(true);
        LevelController.Instance.StopTime();
    }

    public void NextLevel()
    {
        SaveController.Instance.DeleteAllKeys();
        LevelController.Instance.NextLevel();
    }

    public void RestartLevel()
    {
        SaveController.Instance.DeleteAllKeys();
        LevelController.Instance.RestartLevel();
    }

    public void VisitMenu()
    {
        SaveController.Instance.DeleteAllKeys();
        LevelController.Instance.OpenScene(0);
    }

    public void QuitGame()
    {
        LevelController.Instance.QuitGame();
    }
}