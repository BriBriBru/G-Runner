using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculGenerator()
    {

    }

    void LevelOne()
    {
        int firstNumber = Random.Range(0,10);
        int secondNumber = Random.Range(0, 10);

        int sign = Random.Range(0, 1);

        if(sign == 0)
        {
            int answer = firstNumber + secondNumber;

        }
        else if(sign == 1)
        {
            int answer = firstNumber - secondNumber;

        }
    }
}
