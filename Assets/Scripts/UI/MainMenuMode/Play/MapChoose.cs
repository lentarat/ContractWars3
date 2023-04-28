using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapChoose : MonoBehaviour
{
    [SerializeField] private GameObject _mapsParent;
    
    public static string ChosenMapName = "Pool Black";

    void Awake()
    {
        Button[] maps = _mapsParent.GetComponentsInChildren<Button>();
        foreach (Button button in maps)
        {
            button.onClick.AddListener(() => SaveMapName(button.GetComponentInChildren<TextMeshProUGUI>().text));
        }
    }

    private void SaveMapName(string mapName)
    {
        ChosenMapName = mapName;
        StartGame();
    }

    private void StartGame()
    {
        ScenesManager.Instance.LoadMap();
    }
}
