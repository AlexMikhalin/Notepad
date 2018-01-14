using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Notepad.Models;

namespace Notepad.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<Record> records = db.Records.OrderBy(s => s.Sort).ToList();
            return View(records);
        }
        [HttpGet]
        public ActionResult Add()
        {
            Record record = new Record();
            return View(record);
        }

        [HttpPost]
        public ActionResult Add(string Note, int Sort, string Color)
        {
            Record record = new Record();
            record.Note = Note;
            record.Sort = Sort;
            record.Color = Color;
            db.Records.Add(record);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Remove(Guid id)
        {
            Record record = db.Records.SingleOrDefault(x => x.Id == id);
            db.Records.Remove(record);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ToggleNote(Guid id)
        {
            Record record = db.Records.SingleOrDefault(x => x.Id == id);
            if (record.IsTearOut == true)
            {
                record.IsTearOut = false;
            }
            else
            {
                record.IsTearOut = true;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            Record record = db.Records.SingleOrDefault(x => x.Id == id);
            return View(record);
            
        }


        [HttpPost]
        public ActionResult Edit(Record model)
        {
            Record record = db.Records.SingleOrDefault(x => x.Id == model.Id);
            record.Note = model.Note;
            record.Sort = model.Sort;
            record.Color = model.Color;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult _RecordsPartial()
        {
            List<Record> records = db.Records.OrderBy(s => s.Sort).ToList();
            return PartialView(records);
        }

        [HttpGet]
        public ActionResult SwapUp(Guid id)
        {
            Record record = db.Records.OrderBy(s => s.Sort).SingleOrDefault(x => x.Id == id);
            Record prevRecord = db.Records.Where(x => x.Sort < record.Sort).OrderByDescending(x => x.Sort).FirstOrDefault();

            int swap = record.Sort;
            if (prevRecord == null)
            {
                prevRecord = db.Records.OrderByDescending(x => x.Sort).FirstOrDefault();
            }
            record.Sort = prevRecord.Sort;
            prevRecord.Sort = swap;

            db.SaveChanges();
            return View();
        }

            [HttpGet]
        public ActionResult SwapDown(Guid id)
        {
            Record record = db.Records.OrderBy(s => s.Sort).SingleOrDefault(x => x.Id == id);
            Record nextRecord = db.Records.Where(x => x.Sort > record.Sort).OrderBy(x => x.Sort).FirstOrDefault();

            int swap = record.Sort;
            if (nextRecord == null)
            {
                nextRecord = db.Records.OrderBy(x => x.Sort).FirstOrDefault();
            }
            record.Sort = nextRecord.Sort;
            nextRecord.Sort = swap;

            db.SaveChanges();
            return View();
        }


        [HttpGet]
        public ActionResult searchString(string Note)
        {
            var query = Note.Split(' ');
            List<Record> records = db.Records.Where(n=>query.Contains(n.Note)).OrderBy(s => s.Sort).ToList();
            return PartialView("_TRecordsPartial", records);
        }
    }
    

}