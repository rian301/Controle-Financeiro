using AutoMapper;
using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using ControleFinanceiro.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backoffice.Controllers
{
    [Route("categories")]
    public class CategoryController : Controller
    {
        #region GET
        [HttpGet]
        [Route("")]
        //  [AllowAnonymous]
        // [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult<List<CategoryViewModel>>> Get([FromServices] DataContext context)
        {
            var categorias = await context
                .Categories.Include(x => x.Accounts)
                .AsNoTracking()
                .ToListAsync();

            
            return Ok(Mapper.Map<IList<CategoryViewModel>>(categorias));
        }
        #endregion

        #region GET ID
        [HttpGet]
        [Route("{id:int}")]
        //  [AllowAnonymous]
        public async Task<ActionResult<CategoryViewModel>> GetById([FromServices] DataContext context, int id)
        {
            var categoria = await context.Categories.Include(x => x.Accounts).FirstOrDefaultAsync(x => x.Id == id);

            
            return Ok(Mapper.Map<CategoryViewModel>(categoria));
        }
        #endregion

        #region POST
        [HttpPost]
        [Route("")]
        // [Authorize(Roles = "employee")]
        //  [AllowAnonymous]
        public async Task<ActionResult<CategoryViewModel>> Post([FromServices] DataContext context, [FromBody]CategoryViewModel model)
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
              var result =  Mapper.Map<CategoryModel>(model);

                context.Categories.Add(result);
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Não foi possível criar a categoria", ex });

            }
        }
        #endregion

        #region PUT
        [HttpPut]
        [Route("{id:int}")]
        // [Authorize(Roles = "employee")]
        public async Task<ActionResult<CategoryModel>> Put([FromServices] DataContext context, int id, [FromBody]CategoryModel model)
        {
            // Verifica se o ID informado é o mesmo do modelo
            if (id != model.Id)
                return NotFound(new { message = "Categoria não encontrada" });

            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<CategoryModel>(model); // .State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Não foi possível atualizar a categoria" });

            }
        }
        #endregion

        #region DELETE
        [HttpDelete]
        [Route("{id:int}")]
        //[Authorize(Roles = "employee")]
        public async Task<ActionResult<CategoryModel>> Delete(
            [FromServices] DataContext context,
            int id)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound(new { message = "Categoria não encontrada" });

            try
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Não foi possível remover a categoria", ex });

            }
        }
        #endregion
    }
}
