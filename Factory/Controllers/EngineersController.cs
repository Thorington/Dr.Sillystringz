using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectName.Models;

namespace ProjectName.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ProjectNameContext _db;

    public CategoriesController(ProjectNameContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Category> model = _db.Categories.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
      _db.Categories.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisCategory = _db.Categories.Include(category => category.JoinEntities).ThenInclude(join => join.Item).FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    public ActionResult Edit(int id)
    {
      var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      ViewBag.ItemId = new SelectList(_db.Items, "ItemId", "Description");
      return View(thisCategory);
    }

    [HttpPost]
    public ActionResult Edit(Category category, int ItemId)
    {
      if (ItemId != 0 && _db.CategoryItem.FirstOrDefault(_d => _d.ItemId == ItemId && _d.CategoryId == category.CategoryId) == null)
      {
        _db
            .CategoryItem
            .Add(new CategoryItem
            { ItemId = ItemId, CategoryId = category.CategoryId });
        _db.SaveChanges();
      }

      _db.Entry(category).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    // [HttpPost]
    // public ActionResult Edit(Category category)
    // {
    //   _db.Entry(category).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    public ActionResult AddItem(int id)
    {
      var thisCategory =
          _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      ViewBag.ItemId = new SelectList(_db.Items, "ItemId", "Description");
      return View(thisCategory);
    }

    [HttpPost]
    public ActionResult AddItem(Category category, int ItemId)
    {
      if (ItemId != 0)
      {
        _db
            .CategoryItem
            .Add(new CategoryItem()
            { ItemId = ItemId, CategoryId = category.CategoryId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCategory =
          _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCategory =
          _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      _db.Categories.Remove(thisCategory);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
