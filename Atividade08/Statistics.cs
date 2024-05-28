namespace Atividade08
{
    public class Statistics
    {
        public double CalculateAverage(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("The list of numbers cannot be empty");
            }
            return numbers.Average();
        }
    }
}
