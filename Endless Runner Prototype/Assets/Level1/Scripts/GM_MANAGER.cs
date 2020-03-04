using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_MANAGER : MonoBehaviour
{
    [Header("Score Management References")]
    public Transform playerModel;
    public Text scoreDisplayer;

    [Space]
    [Header("Coin Management References")]
    public Text coinDisplay;
    private int coinCount = 0;


    private int score;
    private int BossTriggerScore;
    //Getters and Setters
    //public int CoinCount { get { return coinCount; } set { coinCount = value; } }

    private void Start()
    {
        BossTriggerScore = GameObject.FindGameObjectWithTag("GM").GetComponent<BossManager>().TriggerScore; 
    }

    void LateUpdate()
    {
        score = (int)Mathf.Round(Vector3.Distance(this.transform.position, playerModel.position));
        scoreDisplayer.text = score.ToString();
        if (score >= BossTriggerScore)
        {
            GameObject.FindGameObjectWithTag("GM").GetComponent<BossManager>().ActivateBossMode();
        }
    }

    [HideInInspector]
    public bool doubleCoin = false;
    public void AddCoin(int qty = 1)
    {
        coinCount += qty;

        if (doubleCoin)
        {
            coinCount += qty;
        }

        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        coinDisplay.text = coinCount.ToString();
    }
}
