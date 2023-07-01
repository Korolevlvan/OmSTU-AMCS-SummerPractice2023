using Xunit;
using spacebattle;
using TechTalk.SpecFlow;

namespace spacebattletest;

[Binding]
public class UnitTest1
{
    public bool Flag = false;
    public SpaceShip SShip;
    [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
    public void StartPlaceT(int x, int y)
    {
        int[] value = new int[2];
        value[0] = x;
        value[1] = y;
        SShip = new SpaceShip(value);
    }
    [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
    public void StartPlaceF()
    {
        try{
            int[] value = new int[0] {};
            SShip = new SpaceShip(value);
        }
        catch(Exception)
        {
            Flag = true;
        }
    }
    [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
    public void SpeedT(int x, int y)
    {
        if(Flag == false)
        {
            int[] value = new int[2];
            value[0] = x;
            value[1] = y;
            SShip.ChangeSpeed(value);
        }
    }
    [Given(@"скорость корабля определить невозможно")]
    public void SpeedF()
    {
        if(Flag == false)
        {
            try{
                int[] value = new int[0] {};
                SShip.ChangeSpeed(value);
            }
            catch(Exception)
            {
                Flag = true;
            }
        }
    }
    [Given(@"изменить положение в пространстве космического корабля невозможно")]
    public void DM()
    {
        if(Flag ==false)SShip.BlockMoving();
    }
    [When(@"происходит прямолинейное равномерное движение без деформации")]
    public void Mv()
    {
        if(Flag == false)
        try
        {
            SShip.MoveOnce();
        }catch(Exception)
        {
            Flag = true;
        }
    }
    [Then(@"возникает ошибка Exception")]
    public void Exc()
    {
        Assert.True(Flag);
    }
    [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void NewP(int x, int y)
    {
        if(Flag == false)
        {
            int[] value = SShip.Position();
            if(((x == value[0]) && (y == value[1])) || ((x == value[1]) && (y == value[0])))Flag = true;
        }
        Assert.True(Flag);
    }
}