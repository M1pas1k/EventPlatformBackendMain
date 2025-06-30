using System.Text;
using WebApplication.Application.Interfaces;

namespace WebApplication.Infrastructure.RandomCodeGeneration
{
    public class RandomCodeGeneration : IRandomCodeGeneration
    {
        public string GenerateRandomCode(int length = 10, bool uppercase = true, bool numbers = true)
        {
            string availableChars = "";
            if (uppercase) availableChars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (numbers) availableChars += "0123456789";

            if (string.IsNullOrEmpty(availableChars)) throw new ArgumentException("You must select at least one character set.");

            var random = new Random();
            var code = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                code.Append(availableChars[random.Next(availableChars.Length)]);
            }
            return code.ToString();
        }
    }
}
