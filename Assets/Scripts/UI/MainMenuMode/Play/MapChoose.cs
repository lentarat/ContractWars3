using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapChoose : MonoBehaviour
{
    [SerializeField] private GameObject _mapsParent;
    
    public static string ChosenMapName = "Source";

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
        Debug.Log(mapName + " " + ChosenMapName);
        ChosenMapName = mapName;
        StartGame();
    }

    private void StartGame()
    {
        ScenesManager.Instance.LoadGame();
    }
}
