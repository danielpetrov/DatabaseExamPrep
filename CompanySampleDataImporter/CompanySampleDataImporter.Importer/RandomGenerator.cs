namespace CompanySampleDataImporter.Importer
{
    using System;
    using System.Text;

    public static class RandomGenerator
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstvuwxyz";

        private static Random random = new Random();
        
        public static int GetRandomNumber(int min = 0, int max = int.MaxValue / 2)
        {
            return random.Next(min, max + 1);
        }

        public static string GetRandomString(int minLength = 0, int maxLenght = int.MaxValue / 2)
        {
            var stringLength = random.Next(minLength, maxLenght);

            var result = new StringBuilder();

            for (int i = 0; i < stringLength; i++)
            {
                result.Append(Alphabet[random.Next(0, Alphabet.Length - 1)]);
            }

            return result.ToString();
        }

        public static DateTime GetRandomDate(DateTime? after = null, DateTime? before = null)
        {
            var minDate = after ?? new DateTime(1950, 2, 2, 00, 00, 00);
            var maxDate = before ?? new DateTime(2050, 12, 31, 23, 59, 59);

            var seconds = GetRandomNumber(minDate.Second, maxDate.Second);
            var minutes = GetRandomNumber(minDate.Minute, maxDate.Minute);
            var days = GetRandomNumber(minDate.Day, maxDate.Day);
            var months = GetRandomNumber(minDate.Month, maxDate.Month);
            var years = GetRandomNumber(minDate.Year, maxDate.Year);

            return new DateTime();
        }
    }
}
