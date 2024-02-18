using Portals.Utility;
using UnityEngine;

public class Mirrors : MonoBehaviourSingleton<Mirrors>
{
    [SerializeField] private Mirror[] mirrors;

    public bool[] mirrorConditions;
    public bool playerCondition;

    private void Update()
    {
        for (int i = 0; i < mirrors.Length; i++) // Use mirrors.Count if mirrors is a List
        {
            mirrorConditions[i] = !mirrors[i].senseDoor;
        }
    }

    public void UpdatePlayerCondition(bool condition)
    {
        playerCondition = !condition;
    }

    public bool CheckAllConditions()
    {
        var result = playerCondition;

        foreach (var condition in mirrorConditions)
        {
            result &= condition;
        }

        return result;
    }
}
