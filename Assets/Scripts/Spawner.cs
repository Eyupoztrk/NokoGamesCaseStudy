using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Area inputArea;
    public Area outputArea;

    public Transform inputSpawnerPos;
    public Transform outputSpawnerPos;

    public GameObject spawnObject;
    public float moveSpeed = 5f; // Hareket hýzý

    public float processTime = 1f;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartProcess(); 
        }

    }
    public void StartProcess()
    {
        if (inputArea.AreaItems.Count > 0)
        {
            StartCoroutine(ProcessItem());
        }
    }

    private IEnumerator ProcessItem()
    {


        while(inputArea.AreaItems.Count != 0 && !outputArea.isFull())
        {
            print("spawner çalýþýyor");
            GameObject inputItem = inputArea.DecreaseItem();

            yield return StartCoroutine(MoveToPosition(inputItem, inputSpawnerPos.position));

            yield return new WaitForSeconds(processTime);            
            Destroy(inputItem);
            
            GameObject outputItem = Instantiate(spawnObject, outputSpawnerPos.position, Quaternion.Euler(0,90,0));
            yield return new WaitForSeconds(processTime);
            // yield return StartCoroutine(MoveToPosition(outputItem, outputArea.transform.position));
            outputArea.GetItemFromSpawner(outputItem);
           
           
          
        }
       
    }

    private IEnumerator MoveToPosition(GameObject obj, Vector3 targetPosition)
    {
        while (Vector3.Distance(obj.transform.position, targetPosition) > 0.1f)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}