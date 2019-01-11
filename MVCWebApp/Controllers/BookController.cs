﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWebApp.Models;
using MVCWebApp.DAL;
using System.Data;

namespace MVCWebApp.Controllers
{
    public class BookController : Controller
    {

        private IBookRepository _bookRepository;
        public BookController()
        {
            this._bookRepository = new BookRepository(new BookContext());
        }

        // GET: Book
        public ActionResult Index()
        {
            var books = from book in _bookRepository.GetBooks()
                        select book;
            return View(books);
        }

        public ViewResult Details(int id)
        {
            Books student = _bookRepository.GetBookByID(id);
            return View(student);
        }

        public ActionResult Create()
        {
            return View(new Books());
        }

        [HttpPost]
        public ActionResult Create(Books book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookRepository.InsertBook(book);
                    _bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            Books book = _bookRepository.GetBookByID(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Books book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookRepository.UpdateBook(book);
                    _bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(book);
        }


        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Books book = _bookRepository.GetBookByID(id);
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Books book = _bookRepository.GetBookByID(id);
                _bookRepository.DeleteBook(id);
                _bookRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
        { "id", id },
        { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}