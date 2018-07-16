using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMoney : MonoBehaviour{ //This class generates a money amount within a specified range
    public float generate = 0f;
    public float chance = 0f;
    public float CalculateAmount(float modifierlow, float modifierhigh)
    {
        generate = Mathf.Floor(Random.Range(modifierlow, modifierhigh+1));
        return generate;
    }
    public float CalculateChance()
    {
        chance = Mathf.Floor(Random.Range(1, 101));
        return chance;
    }
}
