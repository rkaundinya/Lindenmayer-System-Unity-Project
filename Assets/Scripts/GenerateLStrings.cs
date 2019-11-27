using UnityEngine;

public class GenerateLStrings : MonoBehaviour
{
    public static void GenerateStringMutations (string axiom, int numOfIterations, 
        LStringData lStringData)
    {
        string currentLString = axiom;

        if (numOfIterations < 0)
        {
            Debug.LogWarning("Number of iterations must be 1 or above");
            return;
        }
        else if (numOfIterations == 0)
        {
            lStringData.LSystemStrings.Add(axiom);
            return;
        }

        lStringData.LSystemStrings.Add(axiom);

        for (int currentIteration = 1; currentIteration < numOfIterations; ++currentIteration)
        {
            Debug.Log("Generate string loop is running");
            for (int i = 0; i < currentLString.Length; ++i)
            {
                char currentChar = currentLString[i];
                string mutation = currentChar.ToString();

                if (lStringData.StringMutationRuleMap.ContainsKey(currentChar))
                {
                    mutation = lStringData.StringMutationRuleMap[currentChar];
                }

                currentLString = currentLString.Insert(i, mutation);
                i += mutation.Length;
                currentLString = currentLString.Remove(i, 1);
                i--;
            }

            lStringData.LSystemStrings.Add(currentLString);
        }
    }
}