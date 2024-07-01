namespace OTUS.HW5
{
    public static class Extensions
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null || !collection.Any())
                throw new ArgumentException("Коллекция пустая либо равна null");

            T maxElement = null;
            float maxNumber = float.MinValue;

            foreach (var item in collection)
            {
                float number = convertToNumber(item);
                if (number > maxNumber)
                {
                    maxNumber = number;
                    maxElement = item;
                }
            }

            return maxElement;
        }
    }
}
