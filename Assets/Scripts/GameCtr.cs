using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ϸ����
/// </summary>
public class GameCtr : MonoBehaviour
{
    public static GameCtr instance;

    public int levelNum;

    public WaterCtr waterCtr;
    public FollowingMouse followingMouse;
    public DrawAimLine drawAimLine;
    public EnergyBar energyBar;

    public UIMgr uiMgr;
    public AnimalMgr anmMgr;

    private int _nowScore = 0;
    public int NowScore
    { 
        get { return _nowScore; } 
        set 
        {
            _nowScore = value;
            uiMgr.OnScoreChange(value);
        }
    }

    private int _goalScore = 1;
    public int GoalScore
    {
        get { return _goalScore; }
        set
        {
            _goalScore = value;
            uiMgr.OnGoalChange(value);
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
    }

    IEnumerator Start()
    {
        waterCtr ??= GameObject.Find("WaterPot").GetComponent<WaterCtr>();
        followingMouse ??= GameObject.Find("WaterPot").GetComponent<FollowingMouse>();
        drawAimLine ??= GameObject.Find("Aimline").GetComponent<DrawAimLine>();
        energyBar ??= GameObject.Find("EnergyBar").GetComponent<EnergyBar>();
        uiMgr ??= GetComponent<UIMgr>();
        anmMgr ??= GetComponent<AnimalMgr>();

        yield return null;
        Init();
    }


    private void Init()
    {
        NowScore = 0;
        GoalScore = 100;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            waterCtr.StartPouring();
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            waterCtr.EndPouring();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OnLevelSuccess()
    {

    }

    public void OnLevelFail()
    {

    }
}
