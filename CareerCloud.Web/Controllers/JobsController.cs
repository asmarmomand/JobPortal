using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.Web.Controllers
{
    public class JobsController : Controller
    {
       // private CareerCloudContext db = new CareerCloudContext();
        private readonly EFGenericRepository<CompanyJobDescriptionPoco> _EF;
        // GET: Jobs

        public JobsController()
        {
            _EF = new EFGenericRepository<CompanyJobDescriptionPoco>();
        }
        public ActionResult Index()
        {

            var companyJobs = _EF.GetAll();//db.CompanyJobs.Include(c => c.CompanyProfiles).Include(c =>c.CompanyJobDescriptions);
            return View(companyJobs);
        }

        // GET: Jobs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyjob = _EF.GetSingle(c => c.Id == id);//db.CompanyJobs.Find(id);
            if (companyjob == null)
            {
                return HttpNotFound();
            }
            return View(companyjob);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            //ViewBag.Company = new SelectList(db.CompanyProfiles, "Id", "CompanyWebsite");
            
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Company,ProfileCreated,IsInactive,IsCompanyHidden")] CompanyJobDescriptionPoco companyJobdescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                companyJobdescriptionPoco.Id = Guid.NewGuid();
                _EF.Add(companyJobdescriptionPoco);
                
                return RedirectToAction("Index");
            }

            //ViewBag.Company = new SelectList(db.CompanyProfiles, "Id", "CompanyWebsite", companyJobPoco.Company);
            return View(companyJobdescriptionPoco);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyJobdescriptionPoco = _EF.GetSingle(c => c.Id == id);//db.CompanyJobs.Find(id);
            if (companyJobdescriptionPoco == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Company = new SelectList(db.CompanyProfiles, "Id", "CompanyWebsite", companyJobPoco.Company);
            return View(companyJobdescriptionPoco);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Company,ProfileCreated,IsInactive,IsCompanyHidden")] CompanyJobDescriptionPoco companyJobdescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                _EF.Update(companyJobdescriptionPoco);
               // db.Entry(companyJobPoco).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Company = new SelectList(db.CompanyProfiles, "Id", "CompanyWebsite", companyJobPoco.Company);
            return View(companyJobdescriptionPoco);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyJobdescriptionPoco = _EF.GetSingle(c => c.Id == id);//db.CompanyJobs.Find(id);
            if (companyJobdescriptionPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobdescriptionPoco);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyJobDescriptionPoco companyJobdescriptionPoco = _EF.GetSingle(c => c.Id == id);//db.CompanyJobs.Find(id);
            _EF.Remove(companyJobdescriptionPoco);
            // db.CompanyJobs.Remove(companyJobdescriptionPoco);
           // db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Apply(Guid? id)
        {
            var p = _EF.GetAll();
            return View(p);
        }

        [HttpPost]
        public ActionResult Apply(Guid id)
        {
            return null;
        }
      
    }
}
