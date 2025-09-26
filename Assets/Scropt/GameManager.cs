using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("プレイヤー")]
    public int life = 10;
    public int coins = 100;

    private void Awake()
    {
        if (Instance == null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoseLife(int amount = 1)
    {
        life -= amount;
        if (life <= 0)
        {
            life = 0;
            GameOver();
        }
        Debug.Log(life);
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        Debug.Log(coins);
    }

    void GameOver()
    {
        Debug.Log("GameOver");
        //ゲームオーバー時の処理
    }
}
