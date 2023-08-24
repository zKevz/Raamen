using Raamen.Model;
using Raamen.Repository;

namespace Raamen.Factory
{
    public static class RamenFactory
    {
        public static Ramen CreateRamen(string name, string meat, string broth, int price)
        {
            return new Ramen()
            {
                Name = name,
                Broth = broth,
                Price = price,
                MeatID = MeatRepository.GetMeatByName(meat).ID
            };
        }
    }
}