using Infraestructure.Model;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Interfaces
{
    public interface IBaseController
    {
        Task<IActionResult> GetAll();
        //Task<IActionResult> GetById(int id);
        Task<IActionResult> Add(User user);
        Task<IActionResult> Edit(User user);
        Task<IActionResult> Delete(User user);
        //Task<IActionResult> DeleteById(int id);

    }
}
