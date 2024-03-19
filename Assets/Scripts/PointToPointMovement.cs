using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PointToPointMovement : MonoBehaviour
{
    public Transform[] runners; // ������ ��������-�������
    public float passDistance = 1.0f; // ��������� ��� �������� ��������

    private int currentRunnerIndex = 0; // ������ �������� ������
    private Transform currentRunner; // ������� ������-�����

    void Start()
    {
        // ���������� ������� ������
        currentRunner = runners[currentRunnerIndex];
    }

    void Update()
    {
        if (runners.Length == 0) return; // ���� ������ ������� ����, ���������� ����������

        // ����������� ��������� �� ���������� ������
        float distanceToNextRunner = Vector3.Distance(transform.position, runners[(currentRunnerIndex + 1) % runners.Length].position);

        // ��������, ����� �� ���������� ��������
        if (distanceToNextRunner < passDistance)
        {
            // ��������� ����� ���������� �������
            currentRunnerIndex = (currentRunnerIndex + 1) % runners.Length;
            currentRunner = runners[currentRunnerIndex];

            // �������� ������ � ������� ����������
            currentRunner.LookAt(runners[(currentRunnerIndex + 1) % runners.Length]);
        }

        // ����������� �������� ������
        currentRunner.Translate(Vector3.forward * Time.deltaTime);
    }
}



