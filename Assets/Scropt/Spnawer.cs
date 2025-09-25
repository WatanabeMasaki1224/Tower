using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spnawer : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints; // �o���|�C���g
    public List<Transform>[] routes; // ���[�g�z���SpawnPoint�Ɠ������Ԃœo�^
    public float spawnInterval = 2f;
    public int maxEnemies = 30; // �ő吶����

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        int spawnIndex = 0;
        int spawnedCount = 0; // ���������G�̃J�E���^�[
        while (spawnedCount < maxEnemies)
        {
            Transform spawn = spawnPoints[spawnIndex];
            List<Transform> path = new List<Transform>(routes[spawnIndex]);

            GameObject enemyObj = Instantiate(enemyPrefab, spawn.position, Quaternion.identity);
            enemyObj.GetComponent<Enemy>().Setup(path);

            spawnIndex = (spawnIndex + 1) % spawnPoints.Length;
            spawnedCount++; // �������𑝂₷
            yield return new WaitForSeconds(spawnInterval);
        }
        Debug.Log("�G�̐������I�����܂���");
    }
}
