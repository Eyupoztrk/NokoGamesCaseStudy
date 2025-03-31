using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    private void Awake()
    {
        Instance = this;
    }


    [SerializeField] private GameObject _joystick;
    [SerializeField] private GameObject _startPanel;

    public int money;
    [SerializeField] private TextMeshProUGUI moneyText;


   [HideInInspector] public bool isStart = false;

    private void Start()
    {
        _startPanel.SetActive(true);
        EarnMoney(0);

    }


    public void StartGame()
    {
        _joystick.SetActive(true);
        _startPanel.SetActive(false);

        isStart = true;
    }


    public void EarnMoney(int moneyAmount)
    {
        money += moneyAmount;
        moneyText.text = money.ToString();
    }
}
