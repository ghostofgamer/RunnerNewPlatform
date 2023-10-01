using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Gradient _gradient;

    private Slider _slider;
    private Coroutine _changer;

    private readonly float _speed = 16f;

    private void Start()
    {
        SetSlider();
    }

    private void OnEnable()
    {
        _player.HealthChanged += HealthChanger;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= HealthChanger;
    }

    private void SetSlider()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.CurrentHealth;
        ColorChanger();
    }

    private void HealthChanger(float currentHealth)
    {
        if (_changer != null)
            StopCoroutine(_changer);

        _changer = StartCoroutine(Changed(currentHealth));
    }

    private IEnumerator Changed(float currentHealth)
    {
        while (_slider.value != currentHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, currentHealth, _speed * Time.deltaTime);
            ColorChanger();
            yield return null;
        }
    }

    private void ColorChanger()
    {
        var needSpeedEvaluate = _slider.value / 100;
        _slider.fillRect.GetComponent<Image>().color = _gradient.Evaluate(needSpeedEvaluate);
    }
}
