using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.DTO_ViewModels;
using OnlineStore.Data.DTO_ViewModels.Admin;
using OnlineStore.Data.Models;
using OnlineStore.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreAspCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UserRoles.ADMIN)]
    public class MuscleLoadController : Controller
    {
        private readonly IMuscleLoadService muscleLoadService;

        public MuscleLoadController(IMuscleLoadService muscleLoadService)
        {
            this.muscleLoadService = muscleLoadService;
        }
        // GET: MuscleLoadController
        public ActionResult Index()
        {
            return View("AdminMuscleLoadIndex");
        }

        public ActionResult GetList()
        {
            List<AdminMuscleLoadViewDTO> itemList = muscleLoadService.GetAllMuscleLoad();
            return Json(new { data = itemList });
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("MuscleLoadId", "MuscleName")] AdminMuscleLoadEditDTO adminMuscleLoadEditDTO)
        {
            if (id != adminMuscleLoadEditDTO.MuscleLoadId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                muscleLoadService.updateMuscleLoad(adminMuscleLoadEditDTO);
            }
            else
            {
                return Json(new SuccessMessageResponse() { Success = false, Message = "Model is invalid!" });
            }

            return Json(new SuccessMessageResponse () { Success = true, Message = "Successfully saved" });
        }
        [HttpPost]
        public IActionResult Create([Bind("MuscleName","Disabled")] AdminMuscleLoadCreateDTO adminMuscleLoadCreateDTO)
        {
            if (ModelState.IsValid)
            {
                muscleLoadService.createMuscleLoad(adminMuscleLoadCreateDTO);
                return Json(new SuccessMessageResponse() { Success = true, Message = "Successfully added" });
            }
            else
            {
                return Json(new SuccessMessageResponse() { Success = false, Message = "Model is invalid!" });
            }
        }

        [HttpPut]
        public IActionResult DeactivateItem(int id)
        {
            muscleLoadService.DeactivateMuscleLoad(id);
            return Json(new SuccessMessageResponse() { Success = true, Message = "Deactivation successful" });
        }

        [HttpPut]
        public IActionResult ActivateItem(int id)
        {
            muscleLoadService.ActivateMuscleLoad(id);
            return Json(new SuccessMessageResponse() { Success = true, Message = "Activation successful" });
        }

    }
}
