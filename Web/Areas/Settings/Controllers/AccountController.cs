﻿using Common;
using MobileHis.Models.ApiModel;
using MobileHis.Models.ViewModel;
using MobileHis_2019.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class AccountController : MobileHis_2019.Controllers.BaseController
    {
        IAccountService _accountService;
        public AccountController(
            ISystemLogService systemLogService, 
            IAccountService accountService
            ) : base(systemLogService)
        {
            _accountService = accountService;
            _accountService.InitialiseIValidationDictionary(new ModelStateWrapper(ModelState));
        }
        // GET: Settings/User
        public ActionResult Index(AccountIndexView model)
        {
            if (_accountService != null)
                model.Accounts = _accountService.GetList(model.Keyword).ToPagedList(model.Page, Config.PageSize);
            return View(model);
        }
        public ActionResult Create()
        {
            return View(new AccountCreateView());
        }
        [HttpPost]
        public ActionResult Create(AccountCreateView model)
        {
            if (ModelState.IsValid)
            {
                _accountService.Create(model);
                if (ModelState.IsValid)
                    EditSuccessfully();
            }
            return View(model);

        }
        public ActionResult Edit(int id)
        {
            return View(_accountService.Edit(id));
        }
        [HttpPost]
        public ActionResult Edit(AccountEditView model)
        {
            if (ModelState.IsValid)
            {
                _accountService.Edit(model);
                if (ModelState.IsValid)
                    EditSuccessfully();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordView model)
        {
            if (ModelState.IsValid)
            {
                _accountService.ChangePassword(model);
                if (ModelState.IsValid)
                {
                    ViewBag.Message = "Setting Successfully";
                    ViewBag.Redirect = Url.Action("/LogOn");
                }
            }
            return View(model);
        }
    }
}