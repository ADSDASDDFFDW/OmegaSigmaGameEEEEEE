using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRecTransform;
    private float _maxValue;

    public GameObject gameplayUI;
    public GameObject gameOverScreene;

    private void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }

    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            PlayerIsDead();
        }

        DrawHealthBar();
    }

    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreene.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireBallCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }
    private void DrawHealthBar()
    {
        valueRecTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }
}
