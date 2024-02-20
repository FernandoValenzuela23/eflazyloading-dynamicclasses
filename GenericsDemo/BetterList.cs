
namespace GenericsDemo
{
    public class BetterList<T>
    {
        private List<T> data = new List<T>();

        public void AddToList(T value)
        {
            data.Add(value);
        }

    }
}
