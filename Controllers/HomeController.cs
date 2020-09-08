using OsobyZaginione.Models;
using System.Linq;
using System.Web.Mvc;

namespace OsobyZaginione.Controllers
{
    public class HomeController : Controller
    {
        private OsobyZagubioneDBEntities _db = new OsobyZagubioneDBEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View(_db.OsobyZagubione.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude="Id")] OsobyZgubione osoba)
        {
            if (!ModelState.IsValid)
                return View();

            _db.OsobyZagubione.Add(osoba);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var EdytujOsobe = (from m in _db.OsobyZagubione where m.Id == id select m).First();

            return View(EdytujOsobe);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(OsobyZgubione EdytujOsobe)
        {
            var original = (from m in _db.OsobyZagubione where m.Id == EdytujOsobe.Id select m).First();

            if (!ModelState.IsValid)
                return View(original);

            _db.Entry(original).CurrentValues.SetValues(EdytujOsobe);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id = 0)
        {
            OsobyZgubione _osoby = _db.OsobyZagubione.Find(id);
            if(_osoby == null)
            {
                return HttpNotFound();
            }
            return View(_osoby);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            OsobyZgubione _osoby = _db.OsobyZagubione.Find(id);
            _db.OsobyZagubione.Remove(_osoby);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
