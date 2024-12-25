using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTimer = 1;
    public float minEdgeDistance = 0;
    public MRUKAnchor.SceneLabels spawnLabels;
    public GameObject prefabToSpawn;
    public float normalOffset;
    private float timer;

    public int spawnTry = 1000;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MRUK.Instance && !MRUK.Instance.IsInitialized)
            return;
        timer += Time.deltaTime;
        if (timer > spawnTimer)
        {
            SpawnEnemy();
            timer -= spawnTimer;
        }
    }

    public void SpawnEnemy()
    {
        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        int currentTry = 0;
        while(currentTry < spawnTry)
        {
            bool hasFoundPosition = room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.VERTICAL, minEdgeDistance, new LabelFilter(spawnLabels), out Vector3 pos, out Vector3 norm);
            if (hasFoundPosition)
            {
                Vector3 randomPositionNoramlOffSet = pos + norm * normalOffset; ;
                randomPositionNoramlOffSet.y = 0;

                Instantiate(prefabToSpawn, randomPositionNoramlOffSet, Quaternion.identity);
                return;
            }
            else
            {
                currentTry++;
            }
        }


    }
}
