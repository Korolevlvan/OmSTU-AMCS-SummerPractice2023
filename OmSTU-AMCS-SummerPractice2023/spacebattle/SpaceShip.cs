namespace spacebattle{

public class SpaceShip
{
        private static bool Ability_to_move = true;
        private static bool Ability_to_Turn = true;
        private static int x;
        private static int y;
        private static int Sx = 0;
        private static int Sy = 0;
        private static int Fuel = 0;
        private static int Fuel_consumption = 0;
        private static int Angle = 0;
        private static int SAngle = 0;
        public SpaceShip(){
            throw new Exception();
        }
        public SpaceShip(int[] value){
            if(value.Length < 4)
            {
                throw new Exception();
            }
            else
            {
                x = value[0];
                y = value[1];
                Fuel = value[2];
                Angle = value[3];
            }
        }
        public void Turn()
        {
            if(Ability_to_Turn)
            {
                Angle += SAngle;
            }
            else throw new Exception();
        }
        public void MoveOnce()
        {
            if((Ability_to_move) && (Fuel >= Fuel_consumption))
            {
                x = x + Sx;
                y = y + Sy;
                Fuel -= Fuel_consumption;
            }
            else throw new Exception();
        }
        public void ChangeSpeed(int[] value)
        {
            if(value.Length < 4)
            {
                throw new Exception();
            }
            else
            {
                Sx = value[0];
                Sy = value[1];
                Fuel_consumption = value[2];
                SAngle = value[3];
            }
        }
        public void BlockMoving()
        {
            Ability_to_move = false;
        }
        public void BlockTurning()
        {
            Ability_to_Turn = false;
        }
        public int[] Position()
        {
            int[] value = new int[2];
            value[0] = x;
            value[1] = y;
            return value;
        }
        public int FuelQuantity()
        {
            return Fuel;
        }
        public int AngleValue()
        {
            return Angle;
        }
}
}