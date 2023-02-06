using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int _NumCoins = 0;
    public TMP_Text coinCountText;
    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void IncreaseCoinCount()
    {
        _NumCoins++;
    }

    // Update is called once per frame
    void Update()
    {
        coinCountText.text = "Coins Collected: " + _NumCoins.ToString() + "/10";

        if (_NumCoins == 10)
        {
            winText.SetActive(true);
        }
    }
}
