using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField]private CanvasGroup _canvas;

    private void Start()
    {
        CloseScreen();
    }

    private void OnEnable()
    {
        _player.Dying += OpenScreen;
    }

    private void OnDisable()
    {
        _player.Dying -= OpenScreen;
    }

    private void OpenScreen()
    {
        Time.timeScale = 0f;
        _canvas.alpha = 1f;
        _canvas.interactable = true;
    }

    private void CloseScreen()
    {
        Time.timeScale = 1f;
        _canvas.alpha = 0f;
        _canvas.interactable = false;
    }
}
