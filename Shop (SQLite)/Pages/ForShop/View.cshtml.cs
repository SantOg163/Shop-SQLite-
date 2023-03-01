using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shop__SQLite_.Data;
using Shop__SQLite_.Models;
using Shop__SQLite_.Services;

namespace Shop__SQLite_.Pages.ForShop
{
    public class ViewModel : PageModel
    {
        public ViewProduct productView { get; set; }
        private readonly Service _service;
        public ViewModel(Service service)
        {
            _service = service;
        }

        public async void OnGet(string name)
        {
            productView=await _service.GetProductView(name);
        }
    }
}
