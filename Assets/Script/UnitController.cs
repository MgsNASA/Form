using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField] float AttackPower = 20;//сила удара
    [SerializeField] float AttackInterval = 100;//средний интервал атак
    [SerializeField] float RunSpeed = 5;//скорость бега
    [SerializeField] float HP = 100;//здоровье

    [SerializeField] bool isAlive; //признаки жизни
    [SerializeField] float FindOpponentIntervalSec = 1f / 3f; // интервал обновления поиска оппонента (три раза в секунду)
    private float _findTimer;

    //Отряд юнита
    [SerializeField] Team Team;

    //список всех живых юнитов на сцене
    static List<UnitController> AllAliveUnits = new List<UnitController>();

    //юнит, которго мы атакуем в данный момент
    UnitController Opponent;

    //наш rigidbody
    Rigidbody rb;

    private void Start()
    {
        isAlive = true;
        rb = GetComponent<Rigidbody>();

        //добавляем себя в список живых юнитов
        AllAliveUnits.Add(this);
    }

    private void Update()
    {
        //если у нас есть опоонент - бежим к нему
        if (Opponent != null && Opponent.isAlive)
            rb.velocity = Vector3.Lerp(rb.velocity, (Opponent.transform.position - transform.position).normalized * RunSpeed, Time.deltaTime * 10);
        else
            rb.velocity = Vector3.zero;
        // ищем оппонента
        FindOpponent();
    }

    private void FindOpponent()
    {
        _findTimer += Time.deltaTime;
        if (_findTimer < FindOpponentIntervalSec) return;

        _findTimer = 0;

        //перебираем живых юнитов, находим ближайшего врага, у которго нет оппонента
        var bestDistance = float.MaxValue;
        var bestUnit = default(UnitController);

        foreach (var unit in AllAliveUnits)//перебираем юнитов
            if (unit.Team != Team)//это враг?
            {
                var distSqr = (transform.position - unit.transform.position).sqrMagnitude;//получаем квадрат расстояния до врага
                if (distSqr < bestDistance)//ближе чем предыдущий кандидат?
                {
                    //запоминаем врага
                    bestDistance = distSqr;
                    bestUnit = unit;
                }
            }

        //нашли блажайшего врага?
        if (bestUnit != null)
        {
            //назначаем его своим оппонентом
            Opponent = bestUnit;
        }
    }

    //мы с кем-то встретились
    private void OnTriggerStay(Collider other)
    {
        if (Opponent == null)
            return;//если у нас нет оппонента - не реагируем

        //это наш оппонент?
        var unit = other.GetComponent<UnitController>();
        if (unit == Opponent && unit.isAlive)
        {
            //атакуем в случайные моменты времени
            if (UnityEngine.Random.Range(0, AttackInterval) < 1)
                AttackOpponent();
        }
    }

    //атакуем врага
    private void AttackOpponent()
    {
        //отнимаем HP
        Opponent.HP = Mathf.Max(0, Opponent.HP - AttackPower);
        //с силой откидываем назад
        Opponent.rb.AddForce((Opponent.transform.position - transform.position).normalized * 100 * AttackPower, ForceMode.Acceleration);
        //он умер?
        if (Opponent.HP <= 0)
            Opponent.OnDead();//вызываем его метод для смерти
    }

    private async void OnDead()
    {
        isAlive = false;

        //вычеркиваем себя из списка живых юнитов
        AllAliveUnits.Remove(this);
        //падаем
        rb.constraints = RigidbodyConstraints.None;
        //обнуляем своего оппонента
        Opponent = null;
        //умираем через 1 сек
        await Task.Delay(1);
        Destroy(gameObject);
    }
}

public enum Team
{
    Red, Blue
}