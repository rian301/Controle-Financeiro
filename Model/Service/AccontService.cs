using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.Model.Service
{
    public class AccontService
    {
        private readonly DataContext _context;
        private float _totalAccounts = 0;
        private float _total;

        public AccontService(DataContext context)
        {
            _context = context;
        }
        public float TotalAccounts(int id)
        {
            var userSalary = (from U in _context.Users
                              join C in _context.Categories on U.Id equals C.UserId
                              join A in _context.Accounts on C.Id equals A.CategoryId
                              where U.Id == id
                              select A.Value)
                              .ToList();

            foreach (var item in userSalary)
            {
                _totalAccounts += item;
            }
            return _totalAccounts;
        }

        public float Saldo(int id)
        {
            var salary = _context.Users
                .Where(x => x.Id == id)
                .Select(x => x.Salary)
                .FirstOrDefault();

           _total = salary - _totalAccounts;

            UserModel userModel = new UserModel(_total);

            return _total;
        }
    }
}
