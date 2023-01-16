using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTracker.Controllers
{
    public class HomeController : Controller
    {
        public static List<Expense> ExpensesData = new List<Expense>() { new Expense() { Amount = 11, Name = "Rent", Id = 1 } };
        
        [HttpGet]
        public ActionResult Index()
        {
            var expenses = GetExpenses();
            return View(expenses);
        }

        private List<Expense> GetExpenses()
        {
            return ExpensesData;
        }
        
        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            Expense expenseData = ExpensesData.FirstOrDefault(x => x.Id == Id) ?? new Expense();
            return View(expenseData);
        }

        [HttpPost]
        public ActionResult SaveExpense(Expense expense)
        {
            if (expense.Id > 0)
            {
                Expense expense1 = ExpensesData.FirstOrDefault(x => x.Id == expense.Id);
                ExpensesData.Remove(expense1);
                ExpensesData.Add( expense);
            }
            else
            {
                ExpensesData.Add(expense);
            }
            return RedirectToAction("Index");
        }

    }
}