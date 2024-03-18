using UnityEngine;
using UnityEngine.UI;

public class GenerateLevels : MonoBehaviour
{
    [SerializeField] private LevelsConfig _levelsConfig;
    [Space(5)]

    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private Transform _contentParent;
    [Space(3)]

    [SerializeField] private GameObject _openCard;
    [SerializeField] private GameObject _closeCard;
    [Space(5)]

    [SerializeField] private GameObject[] _menuMazes;

    private void Start() => Generate();

    private void Generate()
    {
        _levelsConfig.Initialization();
        for (int i = 0; i < _levelsConfig.Levels.Count; i++)
        {
            bool levelLocked = _levelsConfig.Levels[i].Locked;
            GameObject card = Instantiate(levelLocked ? _closeCard : _openCard, 
                                          _contentParent.position, 
                                          Quaternion.identity, 
                                          _contentParent);

            if (card.TryGetComponent(out SetupCard setupCard)) 
                setupCard.Setup(_levelsConfig.Levels[i], i);

            if (i < _menuMazes.Length)
                _menuMazes[i].SetActive(!levelLocked);

            ScrollToHorizontalStart();
        }
    }

    private void ScrollToHorizontalStart()
    {
        _scrollRect.verticalNormalizedPosition = 0;
        _scrollRect.horizontalNormalizedPosition = 0;
    }
}