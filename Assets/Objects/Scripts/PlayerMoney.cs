using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    public static PlayerMoney Instance;

    [SerializeField] private int scoreGame;

    public TextMeshProUGUI scoreTxt;
    private const string prefMoney = "prefMoney";

    private void Awake()
    {
        Instance = this;
        scoreGame = PlayerPrefs.GetInt(prefMoney);
    }

    private void Update()
    {
        scoreTxt.text = scoreGame.ToString();
    }

    public bool TryRemoveMoney(int moneyToRemove)
    {
        if (scoreGame >= moneyToRemove)
        {
            scoreGame -= moneyToRemove;
            PlayerPrefs.SetInt(prefMoney, scoreGame);
            return true;
        }
        else
        {
            return false;
        }
    }
}
