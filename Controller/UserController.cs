using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFinanceiro.Data;
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

        public async Task<ActionResult<UserViewModel>> GetById([FromServices] DataContext context, int id)
        {
            var user = await context
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            // <Para onde vai ser covertido> | (Fonte de dados). Converte o () para <>
            var result = Mapper.Map<UserViewModel>(user);

            return result;
        }

        #endregion

        #region POST
        [HttpPost]
        [Route("")]

        // ActionResult = devolve para o front | FromBody = espera receber
        public async Task<ActionResult<UserViewModel>> Post([FromServices] DataContext context, [FromBody] UserViewModel model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // <Para onde vai ser covertido> | (Fonte de dados). Converte o () para <>
               var result = Mapper.Map<UserModel>(model);

                ServiceUser _serviceUser = new ServiceUser(context);

                context.Users.Add(result);

                if (_serviceUser.CriarUsuario(result))
                {
                    await context.SaveChangesAsync();

                    // Esconde a senha
                    model.Password = "";
                    return model;
                }
                else
                    return BadRequest(new { message = "Não foi possível criar o usuário" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        #endregion

        #region PUT
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<UserViewModel>> Put([FromServices] DataContext context, int id, [FromBody] UserModel model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {

              //  context.Entry(model).State = EntityState.Modified;

                var user = await context
                    .Users
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Password = model.Password;

                var result = Mapper.Map<UserViewModel>(model);
                await context.SaveChangesAsync();
                return result;
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
