using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
  [Authorize(Roles = "Librarian")]
  public class BooksController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public BooksController(UserManager<ApplicationUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    
    [AllowAnonymous]
    public ActionResult Index()
    {
      List<Book> model = _db.Books.ToList();
      return View(model);
    }
    [AllowAnonymous]
    public async Task<ActionResult> UserBooks()
    {
      // var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      // var bookList = _db.ApplicationUsers
      //   .Include(user => user.JoinUserBooks)
      //   .ThenInclude(join => join.Book)
      //   .FirstOrDefault(user => user.Id == UserId);
      // return View(bookList);

      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userBooks = _db.Books.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userBooks);

      // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // var currentUser = await _userManager.FindByIdAsync(userId);
      // var userBooks = _db.Books.Where(entry => entry.User.Id == currentUser.Id).ToList();
      // return View(userBooks);
    }

    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      var thisBook = _db.Books
        .Include(book=> book.JoinEntities)
        .ThenInclude(join => join.Author)
        .FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    public ActionResult Create() 
    {
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "FirstName", "LastName");
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create(Book book, int AuthorId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      book.User = currentUser;
      _db.Books.Add(book);
      _db.SaveChanges();
      if (AuthorId != 0)
      {
        _db.BookAuthors.Add(new BookAuthors() { AuthorId = AuthorId, BookId = book.BookId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
    public ActionResult CheckoutBook(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId ==id);
      return View(thisBook);
    }

    [HttpPost, AllowAnonymous]
    public ActionResult CheckoutBook(Book book)
    {
      var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (UserId != null && !_db.UserBooks.Any(model => model.BookId == book.BookId && model.UserId == UserId))
      {
        _db.UserBooks.Add(new Models.UserBooks() {UserId = UserId, BookId = book.BookId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult AddAuthor(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      var authors = _db.Authors.Select(m=> new {Name = m.FirstName + " " + m.LastName, AuthorId = m.AuthorId});
      ViewBag.AuthorId = new SelectList(authors, "AuthorId", "Name");
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult AddAuthor(Book book, int AuthorId)
    {
      if (AuthorId != 0 && !_db.BookAuthors.Any(model => model.BookId == book.BookId && model.AuthorId ==AuthorId))
      {
        _db.BookAuthors.Add(new BookAuthors() { AuthorId = AuthorId, BookId = book.BookId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult Edit(Book book)
    {
      _db.Entry(book).State=EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed (int id)
    {
      var thisBook = _db.Books.FirstOrDefault(book => book.BookId ==id);
      _db.Books.Remove(thisBook);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult DeleteAuthor(int joinId)
    {
      var joinEntry = _db.BookAuthors.FirstOrDefault(entry => entry.BookAuthorsId == joinId);
      _db.BookAuthors.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}