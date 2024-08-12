namespace Actividad1
{
    public class UserCounter
    {
        private int _count = 0;

        public void Increment()
        {
            _count++;
        }

        public int GetCount()
        {
            return _count;
        }
    }
}
