using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFinanceiro.Data;
using ControleFinanceiro.DTO;
using ControleFinanceiro.Model.Service;
using ControleFinanceiro.Models;
using ControleFinanceiro.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backoffice.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {

        #region GET


        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<UserViewModel>>> Get([FromServices] DataContext context)
        {
            var user = await context
            .Users
            .AsNoTracking()
            .ToListAsync();

            // <Para onde vai ser covertido> | (Fonte de dados). Converte o () para <>
            var result = Mapper.Map<List<UserViewModel>>(user);

            return result;
        }
        #endregion

        #region GET ID
        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionResult<UserCategoryModel>> GetById([FromServices] DataContext context, int id)
        {
            try
            {
                AccontService _accontService = new AccontService(context);
                UserService _userService = new UserService(context);

                var balance = _accontService.CalcularBalancoPorIdUsuario(id);

                var userMapped = Mapper.Map<UserViewModel>(_userService.FindUserById(id));
                userMapped.Balance = balance;

                var x = context.UserCategory
                .Where(x => x.UserId == id)
                .Include(x => x.User)
                .Include(y => y.Category)
                .ThenInclude(y => y.Accounts)
                .FirstOrDefault();

                return x;
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Não foi possível encontrar o usuário", ex });
            }
        }

        #endregion

        #region POST
        [HttpPost]
        [Route("")]

        // ActionResult = devolve para o front | FromBody = espera receber
        public async Task<ActionResult<int>> Post([FromServices] DataContext context, [FromBody] UserDTO model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // <Para onde vai ser covertido> | (Fonte de dados). Converte o () para <>
                var result = Mapper.Map<UserModel>(model);

                UserService _serviceUser = new UserService(context);
                context.Users.Add(result);

                if (_serviceUser.CriarUsuario(result))
                {
                    await context.SaveChangesAsync();

                    // Esconde a senha
                    model.Password = "";
                    return Ok(result.Id);
                }
                else
                    return BadRequest(new { message = "Não foi possível criar o usuário" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost]
        [Route("category")]

        // ActionResult = devolve para o front | FromBody = espera receber
        public ActionResult<int> PostUserCategory([FromServices] DataContext context, [FromBody] UserCategoryDTO model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                UserCategoryService _userCateogoryService = new UserCategoryService(context);

                var newUserCategory = _userCateogoryService.CrateUserCategory(model);

                return newUserCategory.Id;

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex.Message
                });
            }
        }
        #endregion

        #region PUT
        [HttpPut]
        public async Task<ActionResult<UserViewModel>> Put([FromServices] DataContext context, [FromBody] UserDTO model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userService = new UserService(context);

                userService.UpdateUser(model);

                return Ok("Usuário atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Não foi possível editar o usuário", ex });
            }
        }
        #endregion

        #region DELETE
        [HttpDelete]
        [Route("{id:int}")]

        public async Task<ActionResult<UserModel>> Delete([FromServices] DataContext context, int id)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userContext = await context.Users.FindAsync(id);
            if (userContext == null)
                return NotFound(new { message = "Usuário não encontrado" });

            try
            {
                context.Users.Remove(userContext);
                await context.SaveChangesAsync();
                return userContext;
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = " Não foi possível excluir o usuário", ex });
            }
        }
        #endregion
    }
}
