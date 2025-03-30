using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformer : Machine
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoProcess());

    }

    protected override IEnumerator ProcessItem()
    {
        return base.ProcessItem();
    }


}
