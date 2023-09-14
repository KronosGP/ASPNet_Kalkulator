using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNet_Kalkulator.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(string first, string second, string operation)
        {
            double num1, num2;
            if (double.TryParse(first, out num1) && double.TryParse(second, out num2))
            {
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                            ViewBag.ErrorMessage = "Nie można dzielić przez zero!";
                        break;
                    default:
                        ViewBag.ErrorMessage = "Nieznane działanie";
                        break;
                }
                ViewBag.Result = result;
            }
            else
                ViewBag.ErrorMessage = "Nieprzwidłowe dane wejściowe.";
            
            return View("Index");
        }
    }
}
