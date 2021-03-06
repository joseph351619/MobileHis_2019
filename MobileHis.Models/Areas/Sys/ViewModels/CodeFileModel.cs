﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using MobileHis.Data;
using System.Web.Mvc;
using MobileHis.Models.Interface;
using System.ComponentModel.DataAnnotations;

namespace MobileHis.Models.Areas.Sys.ViewModels
{
    public class CodeFileViewModel : BaseSearchModel
    {
        public delegate List<SelectListItem> GetCategoryList(string selectedValue = "", bool hasEmpty = false);
        //public event GetCategoryList CategoryListEvent;
        public IPagedList<CodeFile> CategoryPageList { get; set; }
        public List<SelectListItem> AddItemType { get => DependencyResolver.Current.GetService<GetCategoryList>()(); }
        public List<SelectListItem> AddParentType { get => DependencyResolver.Current.GetService<GetCategoryList>()(hasEmpty: true); }
        public List<SelectListItem> UDPParentType { get => DependencyResolver.Current.GetService<GetCategoryList>()(hasEmpty:true); }
        public List<SelectListItem> ItemTypes { get => DependencyResolver.Current.GetService<GetCategoryList>()(selectedValue:ItemType, hasEmpty: true); }

        public int ID { get; set; }
        [MaxLength(2)]
        public string ItemType { get; set; }
        [MaxLength(8)]
        public string ItemCode { get; set; }
        [MaxLength(50)]
        public string ItemDescription { get; set; }
        [MaxLength(50)]
        public string Remark { get; set; }
        [MaxLength(1)]
        public string CheckFlag { get; set; }
        //[MaxLength(100)]
        //public string ModUser { get; set; }
        public int? ParentCodeFile { get; set; }
    }
}
