namespace spacebattle{

public class SpaceShip
{
        private static bool Ability_to_move = true;
        private static int x;
        private static int y;
        private static int Sx = 0;
        private static int Sy = 0;
        public SpaceShip(){
            throw new Exception();
        }
        public SpaceShip(int[] value){
            if(value.Length == 0)
            {
                throw new Exception();
            }
            else
            {
                x = value[0];
                y = value[1];
            }
        }
        public void MoveOnce()
        {
            if(Ability_to_move)
            {
                x = x + Sx;
                y = y + Sy;
            }
            else throw new Exception();
        }
        public void ChangeSpeed(int[] value)
        {
            if(value.Length == 0)
            {
                throw new Exception();
            }
            else
            {
                Sx = value[0];
                Sy = value[1];
            }
        }
        public void BlockMoving()
        {
            Ability_to_move = false;
        }
        public int[] Position()
        {
            int[] value = new int[2];
            value[0] = x;
            value[1] = y;
            return value;
        }
}
}