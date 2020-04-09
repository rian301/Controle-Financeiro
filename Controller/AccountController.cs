using AutoMapper;
using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using ControleFinanceiro.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backoffice.Controllers
{
    [Route("accounts")]
    public class AccountController : Controller
    {
        #region GET
        [HttpGet]
        [Route("")]
        // [AllowAnonymous]
        public async Task<ActionResult<List<AccountViewModel>>> Get([FromServices] DataContext context)
        {
            var accounts = await context
                .Accounts
                .Include(x => x.Category)
                .AsNoTracking().ToListAsync();

            var result = Mapper.Map<List<AccountViewModel>>(accounts);
            return result;
        }
        #endregion

        #region GET ID
        [HttpGet]
        [Route("{id:int}")]
        // [AllowAnonymous]
        public async Task<ActionResult<AccountViewModel>> GetById([FromServices] DataContext context, int id)
        {
            var product = await context
                .Accounts
                .Include(x => x.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            var result = Mapper.Map<AccountViewModel>(product);
            return result;
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        //  [AllowAnonymous]
        public async Task<ActionResult<List<AccountModel>>> GetByCategory([FromServices] DataContext context, int id)
        {
            var products = await context.Accounts.Include(x => x.Category).AsNoTracking().Where(x => x.CategoryId == id).ToListAsync();
            return products;
        }
        #endregion

        #region POST
        [HttpPost]
        [Route("")]
        //   [Authorize(Roles = "employee")]
        public async Task<ActionResult<AccountViewModel>> Post([FromServices] DataContext context, [FromBody]AccountModel model)
        {
            try
            {
                var result = Mapper.Map<AccountViewModel>(model);

                if (ModelState.IsValid)
                {
                    context.Accounts.Add(model);
                    await context.SaveChangesAsync();
                    return result;
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = "Não foi possível criar a conta", ex});
            }
        }
        #endregion

        #region PUT
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<AccountViewModel>> Put([FromServices] DataContext context, int id, [FromBody] UserModel model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verifica se o id informado é o mesmo do modelo
            if (id != model.Id)
                return NotFound(new { message = "Conta não encontrada" });

            try
            {
                var result = Mapper.Map<AccountViewModel>(model);
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = " Não foi possível criae conta", ex });
            }
        }
        #endregion
    }
}