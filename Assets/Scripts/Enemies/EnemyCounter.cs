using UnityEngine;

public class EnemyCounter : MonoBehaviour
{

   GameObject[] Ecount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Ecount = GameObject.FindGameObjectsWithTag("Enemy");

        if(Ecount.Length == 4)
        {

        }

    }
}
