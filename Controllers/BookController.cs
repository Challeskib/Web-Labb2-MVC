using Labb1_Minimal_Api.Models;
using Labb1_Minimal_Api.Models.DTOS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_Labb1_MVC.Services.ServiceInterfaces;
using ApiResponse = Labb1_Minimal_Api.Models.ApiResponse;


namespace Web_Labb1_MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        public async Task<IActionResult> BookIndex()
        {
            List<Book> bookList = new List<Book>();
            var response = await _bookService.GetAllBooks<ApiResponse>();
            if (response != null && response.IsSuccess)
            {
                bookList = JsonConvert.DeserializeObject<List<Book>>(Convert.ToString(response.Result));
            }

            return View(bookList);
        }



        public async Task<IActionResult> CreateBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.CreateBookAsync<ApiResponse>(model);

                if (response != null && response.IsSuccess)
                {
                    // Book creation was successful, redirect to the book index.
                    return RedirectToAction(nameof(BookIndex));
                }
                else
                {
                    // Handle the case where the book creation failed, perhaps by displaying an error message.
                    // You might want to inspect the 'response' object for details on the failure.
                    ModelState.AddModelError(string.Empty, $"Failed to create the book. Please try again.");
                    ModelState.AddModelError(string.Empty, $"Title: {model.Title}, Description: {model.Description}, Year {model.Title}, Loanable: {model.LoanAble}, AuthorId: {model.AuthorId}, GenreId: {model.GenreId}");

                }
            }
            // If ModelState is not valid or if book creation failed, return to the same view with validation errors.
            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            var response = await _bookService.GetBookById<ApiResponse>(id);

            _logger.LogInformation($"Response : {response.Result}");
            _logger.LogInformation($"Response : {response.IsSuccess}");



            if (response != null && response.IsSuccess)
            {
                Book model = JsonConvert.DeserializeObject<Book>(Convert.ToString(response.Result));

                return View(model);
            }

            return NotFound();
        }


        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _bookService.DeleteBookAsync<ApiResponse>(id);

            if (response == null)
            {
                return NotFound();
            }
            Book model = JsonConvert.DeserializeObject<Book>(Convert.ToString(response.Result));


            return RedirectToAction("BookIndex");
        }

        public async Task<IActionResult> UpdateBook(int id)
        {
            var response = await _bookService.GetBookById<ApiResponse>(id);
            if (response != null && response.IsSuccess)
            {
                EditBookDto model = JsonConvert.DeserializeObject<EditBookDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(EditBookDto model)
        {

            if (ModelState.IsValid)
            {
                var response = await _bookService.UpdateBookAsync<ApiResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(model);
        }

    }
}
