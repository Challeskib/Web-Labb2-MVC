using Labb1_Minimal_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_Labb1_MVC.Services.ServiceInterfaces;
using ApiResponse = Labb1_Minimal_Api.Models.ApiResponse;

namespace Web_Labb1_MVC.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IAuthorService authorService, ILogger<AuthorController> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        public async Task<IActionResult> CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(Author model)
        {
            if (ModelState.IsValid)
            {
                var response = await _authorService.CreateAuthorAsync<ApiResponse>(model);

                if (response != null && response.IsSuccess)
                {
                    // Author creation was successful, redirect to the book index.
                    return RedirectToAction("BookIndex", "Book");

                }
                else
                {
                    // Handle the case where the book creation failed, perhaps by displaying an error message.
                    // You might want to inspect the 'response' object for details on the failure.
                    ModelState.AddModelError(string.Empty, $"Failed to create the Author. Please try again.");
                    ModelState.AddModelError(string.Empty, $"Title: {model.Name}");

                }
            }
            // If ModelState is not valid or if book creation failed, return to the same view with validation errors.
            return View(model);
        }
    }
}
