using GangaPrakashAPI.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GangaPrakash.UI
{
    public class DepartmentController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            List<Department> departmentList = await WebAPIClient.GetAsync<List<Department>>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Department/GetList", Session["AccessToken"].ToString());
            return View(departmentList);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            Department department = await WebAPIClient.GetAsync<Department>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Department/Get", Session["AccessToken"].ToString());
            return View(department);
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department = await WebAPIClient.PostAsync<Department>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Department/Create", department, Session["AccessToken"].ToString());
                    if (department.IsError)
                    {
                        ModelState.AddModelError(department.ErrorMessageFor, department.ErrorMessage);
                        return View(department);
                    }
                    TempData["Message"] = "Department Saved Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                return View(department);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: Department/Edit/5
        public async Task<ActionResult> Edit(Guid Id)
        {
            Department department = await WebAPIClient.GetAsync<Department>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Department/Get?Id=" + Id, Session["AccessToken"].ToString());
            return View("Edit", department);
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department = await WebAPIClient.PutAsync<Department>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Department/Edit", department, Session["AccessToken"].ToString());
                    if (department.IsError)
                    {
                        ModelState.AddModelError(department.ErrorMessageFor, department.ErrorMessage);
                        return View(department);
                    }
                    TempData["Message"] = "Department Updated Successfully";
                    TempData["MessageClass"] = "alert alert-success alert-dismissable";
                    return RedirectToAction("Index");
                }
                return View(department);
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Please try again!";
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
        }

        // GET: Department/Edit/5
        public async Task<ActionResult> Delete(Guid Id)
        {
            Department department = await WebAPIClient.GetAsync<Department>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Department/Get?Id=" + Id, Session["AccessToken"].ToString());
            department = await WebAPIClient.PutAsync<Department>(ConfigurationManager.AppSettings["APIConfiguration"], "api/Department/Delete", department, Session["AccessToken"].ToString());
            if (department.IsError)
            {
                TempData["Message"] = department.ErrorMessage;
                TempData["MessageClass"] = "alert alert-danger alert-dismissable";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Department Deleted Successfully";
            TempData["MessageClass"] = "alert alert-success alert-dismissable";
            return RedirectToAction("Index");
        }
    }
}