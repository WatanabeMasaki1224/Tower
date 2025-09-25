using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spnawer : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints; // 出現ポイント
    public List<Transform>[] routes; // ルート配列をSpawnPointと同じ順番で登録
    public float spawnInterval = 2f;
    public int maxEnemies = 30; // 最大生成数

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        int spawnIndex = 0;
        int spawnedCount = 0; // 生成した敵のカウンター
        while (spawnedCount < maxEnemies)
        {
            Transform spawn = spawnPoints[spawnIndex];
            List<Transform> path = new List<Transform>(routes[spawnIndex]);

            GameObject enemyObj = Instantiate(enemyPrefab, spawn.position, Quaternion.identity);
            enemyObj.GetComponent<Enemy>().Setup(path);

            spawnIndex = (spawnIndex + 1) % spawnPoints.Length;
            spawnedCount++; // 生成数を増やす
            yield return new WaitForSeconds(spawnInterval);
        }
        Debug.Log("敵の生成が終了しました");
    }
}
