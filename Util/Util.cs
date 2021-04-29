using System;
using Model.Logic;
using static View.Print;

namespace Util
{
    public class Menu
    {
        public static void MenuForManager(Manager manager)
        {
            int operation;

            while (true)
            {
                Console.Write("Select operation:\n" +
                                  "1. Print all products\n" +
                                  "2. Print all product names\n" +
                                  "3. Print all product colors\n" +
                                  "4. Print min calorific\n" +
                                  "5. Print max calorific\n" +
                                  "6. Print avg calorific\n" +
                                  "7. Print count vegetable\n" +
                                  "8. Print count fruit\n" +
                                  "9. Print total products of color\n" +
                                  "10. Print products with calories below parameter\n" +
                                  "11. Print products with calories higher parameter\n" +
                                  "12. Print products with calories range\n" +
                                  "13. Print products with yellow or red color\n" +
                                  "14. Print count products given colors\n" +
                                  "0. Exit\n" +
                                  "\nEnter number operation: ");

                operation = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (operation)
                {
                    case 0: return;
                    case 1:
                        Console.WriteLine("All products:\n" + Show(manager.GetAllProducts()));
                        break;
                    case 2:
                        Console.WriteLine("All product names:\n" + Show(manager.GetAllProductNames()));
                        break;
                    case 3:
                        Console.WriteLine("All product colors:\n" + Show(manager.GetAllProductColors()));
                        break;
                    case 4:
                        Console.WriteLine("Min calories: " + manager.GetMinCalories() + "\n");
                        break;
                    case 5:
                        Console.WriteLine("Max calories: " + manager.GetMaxCalories() + "\n");
                        break;
                    case 6:
                        Console.WriteLine("Average calories: " + manager.GetAVGCalories() + "\n");
                        break;
                    case 7:
                        Console.WriteLine("Total vegetables: " + manager.GetCountVegetable() + "\n");
                        break;
                    case 8:
                        Console.WriteLine("Total fruit: " + manager.GetCountFruit() + "\n");
                        break;
                    case 9:
                        Console.WriteLine("Total products of color: " + manager.GetCountProductsOfColor() + "\n");
                        break;
                    case 10:
                        Console.WriteLine("Products:\n" + Show(manager.GetProductsWithCaloriesBelowIndicate()));
                        break;
                    case 11:
                        Console.WriteLine("Products:\n" + Show(manager.GetProductsWithCaloriesHigherIndicate()));
                        break;
                    case 12:
                        Console.WriteLine("Products:\n" + Show(manager.GetProductsWithCaloriesRange()));
                        break;
                    case 13:
                        Console.WriteLine("Products:\n" + Show(manager.GetProductsWithYellowOrRedColor()));
                        break;
                    case 14:
                        manager.PrintCountProductsWithColor();
                        break;
                    default:
                        Console.WriteLine("Error! This operation is missing...\n");
                        break;
                }
            }
        }
    }
}