using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PointToPointMovement : MonoBehaviour
{
    public Transform[] runners; // Массив объектов-бегунов
    public float passDistance = 1.0f; // Дистанция для передачи эстафеты

    private int currentRunnerIndex = 0; // Индекс текущего бегуна
    private Transform currentRunner; // Текущий объект-бегун

    void Start()
    {
        // Назначение первого бегуна
        currentRunner = runners[currentRunnerIndex];
    }

    void Update()
    {
        if (runners.Length == 0) return; // Если массив бегунов пуст, прекратить выполнение

        // Определение дистанции до следующего бегуна
        float distanceToNextRunner = Vector3.Distance(transform.position, runners[(currentRunnerIndex + 1) % runners.Length].position);

        // Проверка, нужно ли передавать эстафету
        if (distanceToNextRunner < passDistance)
        {
            // Следующий бегун становится текущим
            currentRunnerIndex = (currentRunnerIndex + 1) % runners.Length;
            currentRunner = runners[currentRunnerIndex];

            // Разворот бегуна в сторону следующего
            currentRunner.LookAt(runners[(currentRunnerIndex + 1) % runners.Length]);
        }

        // Перемещение текущего бегуна
        currentRunner.Translate(Vector3.forward * Time.deltaTime);
    }
}



