using ControleFinanceiro.Data;
using ControleFinanceiro.DTO;
using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ControleFinanceiro.Model.Service
{
    public class UserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        public bool CriarUsuario(UserModel user)
        {
            if (ValidName(user.UserName) != null)
                throw new InvalidOperationException("O nome ja esta em uso.");
            if (ValidEmail(user.Email) != null)
                throw new InvalidOperationException("O e-mail já está em uso.");

            return true;
        }
        public UserModel ValidName(string name)
        {
            var nameDb = _context.Users
              .Where(x => x.UserName == name)
              .FirstOrDefault();

            return nameDb;
        }

        public UserModel ValidEmail(string email)
        {

            var emailDb = _context.Users
                .Where(x => x.Email == email)
                .FirstOrDefault();

            return emailDb;
        }

        public void UpdateUser(UserDTO dto)
        {

            var userDb = FindUserById(dto.Id.Value);

            userDb.Update(dto.Email, dto.UserName, dto.Password, dto.Salary);

            _context.SaveChangesAsync();
        }

        public UserModel FindUserById(int idUser)
        {
            return _context.Users
                .Where(x => x.Id == idUser)
                .Include(y => y.Categories)
                .FirstOrDefault();
        }
    }
}
