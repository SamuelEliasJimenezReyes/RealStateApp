using RealStateApp.Core.Application.ViewModels.Properties;

namespace RealStateApp.Core.Application.Helpers
{
    public static class GenerateUniquecode
    {
        public static string GenerateUniqueCode(List<PropertiesVM> properties) 
        {
            Random random = new Random();
            HashSet<string> existingCodes = new HashSet<string>(properties.Select(p => p.Code));

            if (existingCodes.Count >= (26 * Math.Pow(10, 5))) 
            {
                throw new InvalidOperationException("Se han agotado todos los códigos posibles. Es necesario cambiar la lógica de generación de códigos.");
            }

            string fullCode;
            do
            {
                string randomLetters = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 2).Select(s => s[random.Next(s.Length)]).ToArray());
                string randomDigits = random.Next(1000, 9999).ToString();

                fullCode = $"{randomLetters}{randomDigits}";
            } while (existingCodes.Contains(fullCode));

            return fullCode;
        }
    }
    

}
