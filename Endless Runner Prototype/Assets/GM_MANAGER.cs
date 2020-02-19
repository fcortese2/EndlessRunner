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



    //Getters and Setters
    //public int CoinCount { get { return coinCount; } set { coinCount = value; } }

    void LateUpdate()
    {
        scoreDisplayer.text = Mathf.Round(Vector3.Distance(this.transform.position, playerModel.position)).ToString();
    }

    public void AddCoin(int qty = 1)
    {
        coinCount += qty;
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        coinDisplay.text = coinCount.ToString();
    }
}
