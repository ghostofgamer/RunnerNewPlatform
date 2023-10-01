using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private float _score;

    private readonly float _speed = 15f;

    private void Update()
    {
        _score += _speed * Time.deltaTime;
        _scoreText.text = _score.ToString("0");
    }
}
