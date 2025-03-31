using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : CutSystem
{
    public Slider treeSlider;
    public GameObject sliderFill;
    public float cuttingTime;
    public GameObject woodenLogPrefab;
    public int woodenLogAmount;

    private void Start()
    {
        treeSlider.maxValue = cuttingTime;
        sliderFill.SetActive(false);
        Starting();
      //  StartCoroutine(Cutting(treeSlider, cuttingTime));
    }

    public override IEnumerator Cutting(Slider treeSlider, float cuttingTime)
    {
        sliderFill.SetActive(true);
        yield return base.Cutting(treeSlider, cuttingTime);

        if (elapsedTime >= cuttingTime)
        {
           SpawnLogs();
        }
    }

    private void SpawnLogs()
    {
        float spawnRadius = 0.5f;
        List<Vector3> spawnedPositions = new List<Vector3>();

        for (int i = 0; i < woodenLogAmount; i++)
        {
            Vector3 spawnPosition;
            int maxAttempts = 20; 
            int attempts = 0;

            do
            {
                spawnPosition = new Vector3(
                    gameObject.transform.localPosition.x  + Random.Range(-0.1f, 0.1f),
                    gameObject.transform.localPosition.y + 0.7f + Random.Range(-0.1f, 0.1f),
                    gameObject.transform.localPosition.z + Random.Range(-0.1f, 0.1f)
                );

                attempts++;
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
