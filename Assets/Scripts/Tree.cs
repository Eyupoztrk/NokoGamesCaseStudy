using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : CutSystem
{
    public Slider treeSlider;
    public float cuttingTime;
    public GameObject woodenLogPrefab;
    public int woodenLogAmount;

    private void Start()
    {
        treeSlider.maxValue = cuttingTime;
        Starting();
      //  StartCoroutine(Cutting(treeSlider, cuttingTime));
    }

    public override IEnumerator Cutting(Slider treeSlider, float cuttingTime)
    {
        yield return base.Cutting(treeSlider, cuttingTime);

        if (elapsedTime >= cuttingTime)
        {
           // var woodenLogParent= Instantiate(woodenLogPrefab, new Vector3(gameObject.transform.localPosition.x -0.3f, gameObject.transform.localPosition.y + 0.7f, gameObject.transform.localPosition.z), Quaternion.identity);
           // woodenLogParent.transform.DetachChildren();
           SpawnLogs();
           
        }
    }

    private void SpawnLogs()
    {
        float spawnRadius = 0.5f; // Obje arasý minimum mesafe
        List<Vector3> spawnedPositions = new List<Vector3>();

        for (int i = 0; i < woodenLogAmount; i++)
        {
            Vector3 spawnPosition;
            int maxAttempts = 20; // Sonsuz döngüyü önlemek için maksimum deneme sayýsý
            int attempts = 0;

            do
            {
                spawnPosition = new Vector3(
                    gameObject.transform.localPosition.x  + Random.Range(-0.1f, 0.1f),
                    gameObject.transform.localPosition.y + 0.7f + Random.Range(-0.1f, 0.1f),
                    gameObject.transform.localPosition.z + Random.Range(-0.1f, 0.1f)
                );

                attempts++;
                // Eðer fazla deneme yapýyorsa, döngüden çýk
                if (attempts > maxAttempts)
                {
                    break;
                }
            } while (spawnedPositions.Exists(pos => Vector3.Distance(pos, spawnPosition) < spawnRadius));

            spawnedPositions.Add(spawnPosition);
            var woodenLogParent = Instantiate(woodenLogPrefab, spawnPosition, Quaternion.identity);
        }

        gameObject.SetActive(false);
    }



}
