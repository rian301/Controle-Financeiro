using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using ControleFinanceiro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.Model.Service
{
    public class AccontService
    {
        private readonly DataContext _context;
        private float _totalAccounts;

        public AccontService(DataContext context)
        {
            _context = context;
        }

        public float CalcularBalancoPorIdUsuario(int idUser)
        {
            var debitos = ObterDebitosPorId(idUser);

            var saldo = ObterSaldoPorId(idUser); // Salario - Contas = SAldo

            return EfetuarCalculo(debitos, saldo); ;
        }

        private float EfetuarCalculo(float debitos, float saldo)
        {
            return saldo - debitos;
        }

        private float ObterDebitosPorId(int idUser)
        {
            var debitos = (from U in _context.Users
                           join UC in _context.UserCategory on U.Id equals UC.UserId
                           join C in _context.Categories on UC.CategoryId equals C.Id
                           join A in _context.Accounts on C.Id equals A.CategoryId
                           where U.Id == idUser
                           select A.Value)
                              .ToList();

            foreach (var item in debitos)
            {
                _totalAccounts += item;
            }
            return _totalAccounts;

        }


        public float ObterSaldoPorId(int idUser)
        {
            float saldoTotal = 0;
            var salary = _context.Users
                .Where(x => x.Id == idUser)
                .Select(x => x.Salary)
                .FirstOrDefault();

            saldoTotal = salary - _totalAccounts;

            return saldoTotal;
        }
    }
}
