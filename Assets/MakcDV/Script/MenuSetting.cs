using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class MenuSetting : MonoBehaviour
{
    [SerializeField] private GameState state;
   
    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    public GameState State => state;
    public Canvas Canvas => _canvas;
    
}