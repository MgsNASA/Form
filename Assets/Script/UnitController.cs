using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField] float AttackPower = 20;//���� �����
    [SerializeField] float AttackInterval = 100;//������� �������� ����
    [SerializeField] float RunSpeed = 5;//�������� ����
    [SerializeField] float HP = 100;//��������

    [SerializeField] bool isAlive; //�������� �����
    [SerializeField] float FindOpponentIntervalSec = 1f / 3f; // �������� ���������� ������ ��������� (��� ���� � �������)
    private float _findTimer;

    //����� �����
    [SerializeField] Team Team;

    //������ ���� ����� ������ �� �����
    static List<UnitController> AllAliveUnits = new List<UnitController>();

    //����, ������� �� ������� � ������ ������
    UnitController Opponent;

    //��� rigidbody
    Rigidbody rb;

    private void Start()
    {
        isAlive = true;
        rb = GetComponent<Rigidbody>();

        //��������� ���� � ������ ����� ������
        AllAliveUnits.Add(this);
    }

    private void Update()
    {
        //���� � ��� ���� �������� - ����� � ����
        if (Opponent != null && Opponent.isAlive)
            rb.velocity = Vector3.Lerp(rb.velocity, (Opponent.transform.position - transform.position).normalized * RunSpeed, Time.deltaTime * 10);
        else
            rb.velocity = Vector3.zero;
        // ���� ���������
        FindOpponent();
    }

    private void FindOpponent()
    {
        _findTimer += Time.deltaTime;
        if (_findTimer < FindOpponentIntervalSec) return;

        _findTimer = 0;

        //���������� ����� ������, ������� ���������� �����, � ������� ��� ���������
        var bestDistance = float.MaxValue;
        var bestUnit = default(UnitController);

        foreach (var unit in AllAliveUnits)//���������� ������
            if (unit.Team != Team)//��� ����?
            {
                var distSqr = (transform.position - unit.transform.position).sqrMagnitude;//�������� ������� ���������� �� �����
                if (distSqr < bestDistance)//����� ��� ���������� ��������?
                {
                    //���������� �����
                    bestDistance = distSqr;
                    bestUnit = unit;
                }
            }

        //����� ���������� �����?
        if (bestUnit != null)
        {
            //��������� ��� ����� ����������
            Opponent = bestUnit;
        }
    }

    //�� � ���-�� �����������
    private void OnTriggerStay(Collider other)
    {
        if (Opponent == null)
            return;//���� � ��� ��� ��������� - �� ���������

        //��� ��� ��������?
        var unit = other.GetComponent<UnitController>();
        if (unit == Opponent && unit.isAlive)
        {
            //������� � ��������� ������� �������
            if (UnityEngine.Random.Range(0, AttackInterval) < 1)
                AttackOpponent();
        }
    }

    //������� �����
    private void AttackOpponent()
    {
        //�������� HP
        Opponent.HP = Mathf.Max(0, Opponent.HP - AttackPower);
        //� ����� ���������� �����
        Opponent.rb.AddForce((Opponent.transform.position - transform.position).normalized * 100 * AttackPower, ForceMode.Acceleration);
        //�� ����?
        if (Opponent.HP <= 0)
            Opponent.OnDead();//�������� ��� ����� ��� ������
    }

    private async void OnDead()
    {
        isAlive = false;

        //����������� ���� �� ������ ����� ������
        AllAliveUnits.Remove(this);
        //������
        rb.constraints = RigidbodyConstraints.None;
        //�������� ������ ���������
        Opponent = null;
        //������� ����� 1 ���
        await Task.Delay(1);
        Destroy(gameObject);
    }
}

public enum Team
{
    Red, Blue
}