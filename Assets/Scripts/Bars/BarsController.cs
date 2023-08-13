using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsController : MonoBehaviour
{
    public static BarsController Singletone = null;
    public List<Bar> AllBars;

    private void Awake()
    {
        if (Singletone == null)
        {
            Singletone = this;
        }

        else
        {
            Destroy(this.gameObject);
        }
    }
}
