using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tree : CutSystem
{
    public Slider treeSlider;
    public float cuttingTime;

    private void Start()
    {
        treeSlider.maxValue = cuttingTime;
        Starting();
      //  StartCoroutine(Cutting(treeSlider, cuttingTime));
    }

    public override IEnumerator Cutting(Slider treeSlider, float cuttingTime)
    {
        print("girdi");
        yield return base.Cutting(treeSlider, cuttingTime);

        if (elapsedTime >= cuttingTime)
        {
            gameObject.SetActive(false);
            
        }
    }
}
