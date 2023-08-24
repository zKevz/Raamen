using Raamen.Repository;

namespace Raamen.Controller
{
    public static class RamenController
    {
        public static string ValidateRamen(string ramenName, string meat, string broth, string priceString)
        {
            if (!ramenName.Contains("Ramen"))
            {
                return "Ramen name must contains 'Ramen'";
            }
            else if (string.IsNullOrEmpty(meat))
            {
                return "Meat must be selected!";
            }
            else if (string.IsNullOrEmpty(broth))
            {
                return "Broth cannot be empty!";
            }
            else if (!int.TryParse(priceString, out int price))
            {
                return "Price must be number!";
            }
            else if (price < 3000)
            {
                return "Price must be at least 3000";
            }
            else if (RamenRepository.IsRamenExistByName(ramenName))
            {
                return "That ramen name already exists!";
            }

            return "Success!";
        }

        public static string ValidateRamenUpdate(string ramenName, string oldRamenName, string meat, string broth, string priceString)
        {
            if (!ramenName.Contains("Ramen"))
            {
                return "Ramen name must contains 'Ramen'";
            }
            else if (string.IsNullOrEmpty(meat))
            {
                return "Meat must be selected!";
            }
            else if (string.IsNullOrEmpty(broth))
            {
                return "Broth cannot be empty!";
            }
            else if (!int.TryParse(priceString, out int price))
            {
                return "Price must be number!";
            }
            else if (price < 3000)
            {
                return "Price must be at least 3000";
            }
            else if (ramenName != oldRamenName && RamenRepository.IsRamenExistByName(ramenName))
            {
                return "That ramen name already exists!";
            }

            return "Success!";
        }
    }
}