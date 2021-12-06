using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHeadElement : MonoBehaviour
{
    [SerializeField] private Canvas _baseMenu;
    [SerializeField] private KiryaGameManager _gameManger;

    private MenuSetting[] _changeElement;
    private Canvas _curretMenu;

    private void Awake()
    {
        _changeElement = GetComponentsInChildren<MenuSetting>();
    }
    private void OnEnable()
    {
        _gameManger.GameEventAction += TurnOnGameMenu;
    }
    private void OnDisable()
    {
        _gameManger.GameEventAction -= TurnOnGameMenu;
    }
    private void TurnOnGameMenu(GameState state)
    {
        if (state == GameState.Run)
        {
            _curretMenu.enabled = false;
            return;
        }
        foreach (var element in _changeElement)
        {
            if (element.State == state)
            {
                element.Canvas.enabled = true;
                _curretMenu = element.Canvas;
            }
        }
        _baseMenu.enabled = true;
    }
    public void TurnOffCanvas(CanvasGroup group)
    {
        group.alpha = 0;
        group.interactable = false;
        group.blocksRaycasts = false;
    }
    public void TurnOnCanvas(CanvasGroup group)
    {
        group.alpha = 1;
        group.interactable = true;
        group.blocksRaycasts = true;
    }
    private void ReturnGame()
    {
         Time.timeScale = 1;
    }

}
