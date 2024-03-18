using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _timerText;

    private FinishLevelController _finishLevelController;

    private float _currentTime;
    private bool _count = false;

    public float GetRemainingTime() => _currentTime;

    public void StartCountdown()
    {
        _timerText.gameObject.SetActive(true);
        _count = true;
    }

    private void Start()
    {
        _finishLevelController = FindObjectOfType<FinishLevelController>();

        string keyName = LevelController.Instance.GetLevelName() + SaveController.REMAINING_TIME_SAVE_NAME;
        if (SaveController.Instance.HasKey(keyName) == false)
            _currentTime = LevelController.Instance.CurrentLevel.ExpectedTime;
    }

    private void Update()
    {
        if (!_count) return;

        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            UpdateTimer(_currentTime);
        } else
        {
            _finishLevelController.DisplayLoseScreen();
        }
    }

    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime);

        _timerText.SetText(seconds.ToString("00"));
    }
}
