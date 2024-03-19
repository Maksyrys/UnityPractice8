using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class RunnersScript : MonoBehaviour
{
    public Transform[] runners; 
    public float speed = 5.0f; 
    public float passDistance = 1.0f; 

    private int currentRunnerIndex = 0; 

    void Update()
    {
        MoveRunner();
    }

    private void MoveRunner()
    {
        if (runners.Length == 0)
            return;

        Transform currentRunner = runners[currentRunnerIndex];

        int nextRunnerIndex = (currentRunnerIndex + 1) % runners.Length;
        Transform nextRunner = runners[nextRunnerIndex];

        float distanceToNextRunner = Vector3.Distance(currentRunner.position, nextRunner.position);

        currentRunner.position = Vector3.MoveTowards(currentRunner.position, nextRunner.position, speed * Time.deltaTime);

        if (distanceToNextRunner < passDistance)
        {
            currentRunnerIndex = nextRunnerIndex;
        }
    }
}

