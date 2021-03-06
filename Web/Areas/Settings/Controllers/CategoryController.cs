﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using MobileHis.Models.ApiModel;
using MobileHis.Models.Areas.Sys.ViewModels;
using MobileHis_2019.Service.Service;
using Newtonsoft.Json;
using X.PagedList;

namespace MobileHis_2019.Areas.Settings.Controllers
{
    public class CategoryController : MobileHis_2019.Controllers.BaseAPIController<CodeFileViewModel>
    {
        ICodeFileService _codeFileService;
        private ModelStateWrapper _modelState;
        public CategoryController(ICodeFileService codeFileService, ISystemLogService systemLogService) : base(systemLogService)
        {
            codeFileService.InitialiseIValidationDictionary
               (new ModelStateWrapper(this.ModelState));
            IService = codeFileService;
            _codeFileService = codeFileService;
        }
        [HttpGet]
        public string GetListByItemType(string typeCode)
        {
            return JsonConvert.SerializeObject(_codeFileService.GetDropDownList(typeCode));
        }
    }
}