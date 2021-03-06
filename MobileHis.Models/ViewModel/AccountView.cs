﻿
using LocalRes;
using MobileHis.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;
using Common;

namespace MobileHis.Models.ViewModel
{
    public class AccountIndexView : BaseSearchModel
    {
        public IPagedList<Account> Accounts { get; set; }
    }
    public class DepartmentCheckBox : CheckBoxModel { }
    public class RoleCheckBox : CheckBoxModel { }
    public class AccountView
    {
        public delegate IList<DepartmentCheckBox> GetDepartmentList(bool isRgister);
        public delegate IList<RoleCheckBox> GetRoleList();

        [Display(ResourceType = typeof(Resource), Name = "Account_UserNo")]
        [Required]
        public string UserNo { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_Name")]
        [Required]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Comm_Account")]
        [Required]
        public string Email { get; set; }


        //[Display(ResourceType = typeof(Resource), Name = "Account_Dept")]
        //public int[] Acc2Dept { get; set; }
        //[Display(ResourceType = typeof(Resource), Name = "Account_RegDept")]
        //public int[] RegAcc2Dept { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Account_JobTitle")]
        // public int? Title_id { get; set; }
        public string Title { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Account_Tel")]
        public string Tel { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Gender")]
        public string Gender { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Birthday")]
        public DateTime? Birthday { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Comment")]
        public string Comment { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Experience")]
        public string Experience { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Major")]
        public string Major { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Account_Expertise")]
        public string Expertise { get; set; }

        

        //[Display(ResourceType = typeof(Resource), Name = "ModDate")]
        //public DateTime? ModDate { get; set; }

        //[Display(ResourceType = typeof(Resource), Name = "ModUser")]
        //public string ModUser { get; set; }

        public byte[] Pic { get; set; }
        #region CheckBox
        IList<DepartmentCheckBox> _selectedDepartments;
        IList<DepartmentCheckBox> _selectedBureauDepartments;
        IList<RoleCheckBox> _selectedRoles;
        public IList<DepartmentCheckBox> AvailableDepartments
        {
            get
            {
                if (_selectedDepartments == null)
                    _selectedDepartments = DependencyResolver.Current.GetService<GetDepartmentList>()(false);
                if (!DepartmentIDs.IsNullOrEmpty())
                    _selectedDepartments.Where(a => DepartmentIDs.OrEmptyIfNull().Contains(a.Id)).ToList().ForEach(a => a.IsSelected = true);
                return _selectedDepartments;
            }
        }
        public IList<DepartmentCheckBox> AvailablebureauDepartments {
            get
            {
                if(_selectedBureauDepartments == null)
                    _selectedBureauDepartments = DependencyResolver.Current.GetService<GetDepartmentList>()(true);
                if (!BureauDepartmentIDs.IsNullOrEmpty())
                    _selectedBureauDepartments.Where(a => BureauDepartmentIDs.OrEmptyIfNull().Contains(a.Id)).ToList().ForEach(a => a.IsSelected = true);
                return _selectedBureauDepartments;
            }
        }
        public IList<RoleCheckBox> Roles {
            get
            {
                if(_selectedRoles == null)
                    _selectedRoles = DependencyResolver.Current.GetService<GetRoleList>()();
                if (!RoleIDs.IsNullOrEmpty())
                    _selectedRoles.Where(a => RoleIDs.OrEmptyIfNull().Contains(a.Id)).ToList().ForEach(a => a.IsSelected = true);
                return _selectedRoles;
            }
        }
        //public IList<DepartmentCheckBox> SelectedDepartments {
        //    get
        //    {
        //        if (!DepartmentIDs.IsNullOrEmpty())
        //        {
        //            _selectedDepartments.Where(a => DepartmentIDs.OrEmptyIfNull().Contains(a.Id)).ToList().ForEach(a => a.IsSelected = true);
        //        }
        //        return _selectedDepartments;
        //    }
        //}
        //public IList<DepartmentCheckBox> SelectedBureauDepartments
        //{
        //    get
        //    {
        //        if (!BureauDepartmentIDs.IsNullOrEmpty())
        //        {
        //            _selectedBureauDepartments.Where(a => BureauDepartmentIDs.OrEmptyIfNull().Contains(a.Id)).ToList().ForEach(a => a.IsSelected = true);
        //        }
        //        return _selectedBureauDepartments;
        //    }
        //}
        //public IList<RoleCheckBox> SelectedRoles
        //{
        //    get
        //    {
        //        if (!RoleIDs.IsNullOrEmpty())
        //        {
        //            _selectedRoles.Where(a => RoleIDs.OrEmptyIfNull().Contains(a.Id)).ToList().ForEach(a => a.IsSelected = true);
        //        }
        //        return _selectedRoles;
        //    }
        //}
        [Display(ResourceType = typeof(Resource), Name = "Account_Dept")]
        public int[] DepartmentIDs { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Account_RegDept")]
        public int[] BureauDepartmentIDs { get; set; }
        public int[] RoleIDs { get; set; }
        #endregion
    }
    public class myProfileEditView : AccountView
    {
        public int ID { get; set; }
        public string ImgName { get; set; }
    }
    public class AccountCUView : AccountView    
    {
        private string _isDoctor;
        [Display(ResourceType = typeof(Resource), Name = "Account_Card")]
        public string Card { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Account_Status")]
        public string Status { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IsLockedOut")]
        public string IsLockedOut { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IsDoctor")]
        public string IsDoctor { get => _isDoctor.IsNullOrEmpty()?"":"Y"; set => _isDoctor = value; }
        //[Display(ResourceType = typeof(Resource), Name = "CreateDate")]
        //public DateTime? CreateDate { get; set; }
        public List<SelectListItem> StatusSelectedList
        {
            get => new List<SelectListItem>()
        {
            new SelectListItem(){ Text=LocalRes.Resource.Account_Status_01, Value="", Selected=Status==""},
            new SelectListItem(){ Text=LocalRes.Resource.Account_Status_02, Value="02", Selected=Status=="02"},
            new SelectListItem(){ Text=LocalRes.Resource.Account_Status_03, Value="03", Selected=Status=="03"},
            new SelectListItem(){ Text=LocalRes.Resource.Account_Status_04, Value="04", Selected=Status=="04"},
            new SelectListItem(){ Text=LocalRes.Resource.Account_Status_99, Value="99", Selected=Status=="99"}
        };
        }

    }
    public class AccountCreateView : AccountCUView
    {
        [Display(ResourceType = typeof(Resource), Name = "Account_Password")]
        [Required]
        public string Password { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Account_confirm_password")]
        [Required]
        [System.ComponentModel.DataAnnotations.CompareAttribute("Password")]
        public string confirm_password { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "LastLoginDate")]
        public DateTime? LastLoginDate { get; set; }
    }

    public class AccountEditView : AccountCUView
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
    }


    public class ChangePasswordView
    {
        [Display(ResourceType = typeof(Resource), Name = "Changepassword_Password")]
        [Required]
        public string Password { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Changepassword_newPassword")]
        [Required]
        public string newPassword { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Changepassword_confirm_newPassword")]
        [Required]
        [System.ComponentModel.DataAnnotations.CompareAttribute("newPassword")]
        public string confirm_newPassword { get; set; }

    }
}