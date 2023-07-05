namespace SortierAlgorithmus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();

            #region Starting Menu

            menu.PrintTitle();
            menu.MenuRequest();

            #endregion
        }
    }
}