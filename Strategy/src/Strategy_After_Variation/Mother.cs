using Strategy_After_Variation.Domain;

namespace Strategy_After_Variation
{
    public static class Mother
    {

        public static Order CreateOrder()
        {
            return new Order()
            {
                Destination = Mother.CreateAddress_Destination(),
                Origin = Mother.CreateAddress_Origin()
            };
        }

        public static Address CreateAddress_Origin()
        {
            return new Address()
            {
                ContactName = "David Starr",

                AddressLine1 = "185 Lincoln St.",
                AddressLine2 = "Suite 305",
                AddressLine3 = null,
                City = "Hingham",
                Country = "U.S.",
                Region = "MA",
                PostalCode = "02043-1741"
            };
        }

        public static Address CreateAddress_Destination()
        {
            return new Address()
            {
                ContactName = "Homer Simpson",

                AddressLine1 = "123 Elm",
                AddressLine2 = null,
                AddressLine3 = null,
                City = "Springfield",
                Country = "U.S.",
                Region = "Iowa",
                PostalCode = "11111"
            };
        }
    }
}