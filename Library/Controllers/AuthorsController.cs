using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
    [Authorize(Roles = "Librarian")]
    public class AuthorsController : Controller 
    {
      private readonly LibraryContext _db;
      public AuthorsController(LibraryContext db)
      {
        _db = db;
      }

      [AllowAnonymous]
      public ActionResult Index()
      {
        List<Author> model = _db.Authors.ToList();
        return View(model);
      }

      public ActionResult Create()
      {
        return View();
      }
      [HttpPost]
      public ActionResult Create(Author author)
      {
        _db.Authors.Add(author);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      [AllowAnonymous]
      public ActionResult Details(int id)
      {
        var thisAuthor = _db.Authors
          .Include(author => author.JoinEntities)
          .ThenInclude(join => join.Book)
          .FirstOrDefault(author => author.AuthorId == id);
          return View(thisAuthor);
      }
      public ActionResult AddBook(int id)
      {
        var thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
        ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
        return View(thisAuthor);
      }
      [HttpPost]
      public ActionResult AddBook(Author author, int BookId)
      {
        if (BookId != 0 && !_db.BookAuthors.Any(model=> model.AuthorId == author.AuthorId && model.BookId == BookId))
        {
          _db.BookAuthors.Add(new BookAuthors() { BookId = BookId, AuthorId = author.AuthorId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      public ActionResult Edit(int id)
      {
        var thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
        return View(thisAuthor);
      }
      [HttpPost]
      public ActionResult Edit(Author author)
      {
        _db.Entry(author).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      public ActionResult Delete(int id)
      {
        var thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
        return View(thisAuthor);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult DeleteConfirmed(int id)
      {
        var thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
        _db.Authors.Remove(thisAuthor);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
}