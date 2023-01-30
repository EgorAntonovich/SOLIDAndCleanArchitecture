using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models.LeaveType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.MVC.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
            this._leaveTypeService = leaveTypeService;
        }

        // GET: LeaveTypes
        public async Task<ActionResult> Index()
        {
            var model = await _leaveTypeService.GetLeaveTypes();
            return View(model);
        }

        // // GET: LeaveTypes/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(model);
        }


        // GET: LeaveTypesController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }
        
        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<ActionResult> Create(CreateLeaveTypeViewModel leaveTypeViewModel)
         {
             try
             {
                 var response = await _leaveTypeService.CreateLeaveType(leaveTypeViewModel);
                 if (response.Success)
                 {
                     return RedirectToAction(nameof(Index));
                 }
                 ModelState.AddModelError("", response.ValidationErrors);

             }
             catch (Exception e)
             {
                 ModelState.AddModelError("", e.Message);
             }
             return View();
         }
        // GET: LeaveTypes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(model);
        }
        
        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LeaveTypeViewModel viewModel)
        {
            try
            {
                var response = await _leaveTypeService.UpdateLeaveTypes(id, viewModel);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(viewModel);
        }

        // POST: LeaveTypes/Delete/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _leaveTypeService.DeleteLEaveType(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return BadRequest();
        }
    }
}