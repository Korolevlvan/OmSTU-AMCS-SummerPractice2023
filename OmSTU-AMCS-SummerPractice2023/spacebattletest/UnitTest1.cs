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
        int[] value = new int[4];
        value[0] = x;
        value[1] = y;
        value[2] = 2;
        value[3] = 0;
        SShip = new SpaceShip(value);
    }
    [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
    public void StartAngleT(int a)
    {
        int[] value = new int[4];
        value[0] = 0;
        value[1] = 0;
        value[2] = 2;
        value[3] = a;
        SShip = new SpaceShip(value);
    }
    [Given(@"космический корабль, угол наклона которого невозможно определить")]
    public void StartAngleF()
    {
        try
        {
            int[] value = new int[3];
            value[0] = 0;
            value[1] = 0;
            value[2] = 2;
            SShip = new SpaceShip(value);
        }
        catch(Exception)
        {
            Flag = true;
        }
    }
    [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
    public void StartPlaceTFuel(int f)
    {
        int[] value = new int[4];
        value[0] = 0;
        value[1] = 0;
        value[2] = f;
        value[3] = 0;
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
            int[] value = new int[4];
            value[0] = x;
            value[1] = y;
            value[2] = 1;
            value[3] = 0;
            SShip.ChangeSpeed(value);
        }
    }
    [Given(@"имеет мгновенную угловую скорость (.*) град")]
    public void SpeedTAngle(int a)
    {
        if(Flag == false)
        {
            int[] value = new int[4];
            value[0] = 0;
            value[1] = 0;
            value[2] = 0;
            value[3] = a;
            SShip.ChangeSpeed(value);
        }
    }
    [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
    public void SpeedTFuel(int f)
    {
        if(Flag == false)
        {
            int[] value = new int[4];
            value[0] = 0;
            value[1] = 0;
            value[2] = f;
            value[3] = 0;
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
    [Given(@"мгновенную угловую скорость невозможно определить")]
    public void SpeedAngleF()
    {
        if(Flag == false)
        {
            try{
                int[] value = new int[3];
                value[0] = 0;
                value[1] = 0;
                value[2] = 2;
                SShip.ChangeSpeed(value);
            }
            catch(Exception)
            {
                Flag = true;
            }
        }
    }
    [Given(@"невозможно изменить уголд наклона к оси OX космического корабля")]
    public void ATT()
    {
        if(Flag == false)
        {
            SShip.BlockTurning();
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
    [When(@"происходит вращение вокруг собственной оси")]
    public void Tr()
    {
        if(Flag == false)
        try
        {
            SShip.Turn();
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
    [Then(@"новый объем топлива космического корабля равен (.*) ед")]
    public void NewF(int f)
    {
        if(Flag == false)
        {
            int value = SShip.FuelQuantity();
            if(f == value)Flag = true;
        }
        Assert.True(Flag);
    }
    [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
    public void NewA(int a)
    {
        if(Flag == false)
        {
            int value = SShip.AngleValue();
            if(a == value)Flag = true;
        }
        Assert.True(Flag);
    }
}