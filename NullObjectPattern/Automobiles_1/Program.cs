namespace Automobiles
{
    internal static class Program
    {
        private static void Main()
        {
            var autoRepository = new AutoRepository();
            

//            var mini = autoRepository.Find(new Guid("5E791286-902A-477A-86A4-B1424CCCB6B7"));
//            if(mini == null)
//                return ;
//
//            mini.Start();
//            mini.Stop();


            var automobiles = autoRepository.FindAllByName("ford");
            foreach (var automobile in automobiles)
            {
                automobile.Start();
                automobile.Stop();
            }
        }
    }
}