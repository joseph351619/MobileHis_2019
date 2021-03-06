﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Reflection;

namespace MobileHis.Data
{
    public class Patient
    {
        public Patient() { }

        private string PrivateFirstName = string.Empty;
        private string PrivateMidName = string.Empty;
        private string PrivateSurName = string.Empty;

        [Key]
        [MaxLength(12)]
        public string PatientID { get; set; }
        [MaxLength(20)]
        public string NationalID { get; set; }
        [MaxLength(50)]
        public string SurName
        {
            get { return PrivateSurName; }
            set { 
                PrivateSurName = string.IsNullOrEmpty(value) ? "" : value.ToUpper(); 
            }
        }
        [MaxLength(50)]
        public string FirstName
        {
            get { return PrivateFirstName; }
            set
            {
                PrivateFirstName = string.IsNullOrEmpty(value) ? "" : value.ToUpper();
            }
        }
        [MaxLength(1)]
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        [MaxLength(50)]
        public string Tel { get; set; }
        [MaxLength(50)]
        public string MobilePhone { get; set; }

        public int? Married { get; set; }
        public int? Occupation { get; set; }
        [MaxLength(100)]
        public string Occupation_Others { get; set; }
        [MaxLength(1)]
        public string BloodType { get; set; }
        [MaxLength(1)]
        public string Allergic { get; set; }
        [MaxLength]
        public string AllergicDesc { get; set; }
        [MaxLength]
        public string PastHistory { get; set; }
        [MaxLength]
        public string FamilyHistory { get; set; }

        [MaxLength(1)]
        public string HIV { get; set; }
        //[MaxLength]
        //public string HIVDesc { get; set; }
        [MaxLength(1)]
        public string TB { get; set; }
        //[MaxLength]
        //public string TBDesc { get; set; }
        [MaxLength(1)]
        public string Disability { get; set; }
        //[MaxLength]
        //public string DisabilityDesc { get; set; }
        public int? TA { get; set; }
        [MaxLength(100)]
        public string TA_Others { get; set; }
        public int? Village { get; set; }
        [MaxLength(100)]
        public string Village_Others { get; set; }
        public int? District { get; set; }
        [MaxLength(300)]
        public string Address { get; set; }
        [MaxLength(5)]
        public string AddressZipcode { get; set; }
        [MaxLength(300)]
        public string PostAddress { get; set; }
        [MaxLength(5)]
        public string PostAddressZipcode { get; set; }

        public int? Nationality { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public string ImagePath { get; set; }
        [MaxLength(50)]
        public string GuardiansName { get; set; }
        public int? GuardiansRelation { get; set; }
        [MaxLength(50)]
        public string GuardiansPhone { get; set; }
        public DateTime? FirstVisitDate { get; set; }
        public DateTime? LastVisitDate { get; set; }
        public DateTime? FirstAdmission { get; set; }
        public DateTime? LastAdmission { get; set; }
        public int? Insurance { get; set; }
        public int? InsuranceCategory { get; set; }
        public int? ArrearsTimes { get; set; }
        [MaxLength]
        public string Comment { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? CreateDate { get; set; }
        [MaxLength(30)]
        public string Language { get; set; }
        public string FingerData { get; set; }
        public string FingerData1 { get; set; }
        public string FingerData2 { get; set; }
        public string FingerData3 { get; set; }
        public string FingerData4 { get; set; }

        public string FingerImageData { get; set; }
        public string AttachmentPath1 { get; set; }
        public string AttachmentPath2 { get; set; }
        public string AttachmentPath3 { get; set; }

        public DateTime? ModDate { get; set; }
        [MaxLength(100)]
        public string ModUser { get; set; }

       
        //[MaxLength(50)]
        //public string SocialSecurityNo { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonPhone { get; set; }
        //public string ContactPersonRelationship { get; set; }
        public int? ContactPersonRelationship { get; set; }
        public DateTime? PassportIssueDate { get; set; }
        public DateTime? PassportExpiredDate { get; set; }
        [MaxLength(50)]
        public string MidName
        {
            get { return PrivateMidName; }
            set
            {
                PrivateMidName = string.IsNullOrEmpty(value) ? "" : value.ToUpper();
            }
        }

        public int? Country { get; set; }

        //下面的是可能比較不會用到的
        [MaxLength(50)]
        public string MotherFName { get; set; }
        [MaxLength(50)]
        public string MotherMName { get; set; }
        [MaxLength(50)]
        public string MotherLName { get; set; }
        [MaxLength(50)]
        public string FatherFName { get; set; }
        [MaxLength(50)]
        public string FatherMName { get; set; }
        [MaxLength(50)]
        public string FatherLName { get; set; }

        [MaxLength(30)]
        public string Company { get; set; }
        [MaxLength(30)]
        public string Employer { get; set; }

        public int PatientFrom { get; set; }

        [MaxLength(1)]
        public string Smoking { get; set; }
        [MaxLength(1)]
        public string Diabetes { get; set; }
        [MaxLength(1)]
        public string Alcohol { get; set; }


        #region 泰國新增
        public int? MRDTYPE { get; set; }
        public int? Title { get; set; }
        public int? Title_Eng { get; set; }

        public string FirstName_Eng { get; set; }
        public string LastName_Eng { get; set; }
        public string MidName_Eng { get; set; }

        public int? HnOther { get; set; }
        public int? Material { get; set; }

        public int? ResdentialType { get; set; }
        public string Residential { get; set; }
        public int? ReceiveHospitalNews { get; set; }
        public string PassportID { get; set; }

        #endregion 泰國
        #region ForeignKey
        [ForeignKey("Occupation")]
        public virtual CodeFile Occupation_CodeFile { get; set; }
        [ForeignKey("TA")]
        public virtual CodeFile TA_CodeFile { get; set; }
        [ForeignKey("Village")]
        public virtual CodeFile Village_CodeFile { get; set; }
        [ForeignKey("District")]
        public virtual CodeFile District_CodeFile { get; set; }
        [ForeignKey("Nationality")]
        public virtual CodeFile Nationality_CodeFile { get; set; }
        [ForeignKey("GuardiansRelation")]
        public virtual CodeFile GuardiansRelation_CodeFile { get; set; }
        [ForeignKey("Insurance")]
        public virtual CodeFile Insurance_CodeFile { get; set; }
        [ForeignKey("InsuranceCategory")]
        //public virtual CodeFile InsuranceCategory_CodeFile { get; set; }
        //[ForeignKey("ReligionId")]
        public virtual CodeFile Religion_CodeFile { get; set; }
        [ForeignKey("ContactPersonRelationship")]
        public virtual CodeFile ContactPersonRelationship_CodeFile { get; set; }
        [ForeignKey("Married")]
        public virtual CodeFile Married_CodeFile { get; set; }

        #region PatientHomeAddress
        [ForeignKey("Country")]
        public virtual CodeFile Country_CodeFile { get; set; }
        #endregion


        //[ForeignKey("Household_Head_PatientId")]
        //public virtual Patient Household_Head_Patient { get; set; }

        #endregion

        #region ICollection
        public virtual ICollection<OpdRegister> OpdRegister { get; set; }
        public virtual ICollection<OpdRecord> OpdRecord { get; set; }
        public virtual ICollection<VitalSign> VitalSign { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecord { get; set; }
        public virtual ICollection<PatientAdmissionForm> AdmissionForm { get; set; }
        #endregion


        #region NotMapped
        [NotMapped]
        public int? Age
        {
            get
            {
                if (Birthday.HasValue)
                {
                    int age = DateTime.Today.Year - Birthday.Value.Year;
                    if (DateTime.Now.DayOfYear < Birthday.Value.DayOfYear)
                        age--;
                    //int dy = DateTime.Today.Year - Birthday.Value.Year;
                    //int dm = DateTime.Today.Month - Birthday.Value.Month;
                    //int dd = DateTime.Today.Day - Birthday.Value.Day;
                    //if (dm < 0 || (dm == 0 && dd < 0))
                    //{
                    //    dy -= 1;
                    //}
                    //return dy < 0 ? 0 : dy;
                    return age >= 0 ? age : 0;
                }
                else
                {
                    return null;
                }
            }
        }
        [NotMapped]
        public string PatientName
        {
            get
            {
                return this.FirstName + " " + this.MidName + " " + this.SurName;
            }
        }
        [NotMapped]
        public string PatientFatherName
        {
            get
            {
                if (string.IsNullOrEmpty(FatherFName) && string.IsNullOrEmpty(FatherMName) && string.IsNullOrEmpty(FatherLName)) return "";
                return this.FatherFName + " " + this.FatherMName + " " + this.FatherLName + "(Father)";
            }
        }
        [NotMapped]
        public string PatientMotherName
        {
            get
            {
                if (string.IsNullOrEmpty(MotherFName) && string.IsNullOrEmpty(MotherMName) && string.IsNullOrEmpty(MotherLName)) return "";
                return this.MotherFName + " " + this.MotherMName + " " + this.MotherLName + "(Mother)";
            }
        }
     
        [NotMapped]
        public string PermanentAddress
        {
            get
            {
                return  (Country.HasValue ? Country_CodeFile.ItemDescription : "");
            }
        }
        #endregion

        public void CopyDataFrom(Patient oldData)
        {
            var properties = this.GetType().BaseType.GetProperties();
            foreach (var property in properties)
            {
                if (IsAcceptType(property) 
                    && ExcludeProperty(property) 
                    && property.CanWrite)
                {
                    var value = property.GetValue(oldData);
                    property.SetValue(this, value);
                }
            }
        }

        private bool IsAcceptType(PropertyInfo property)
        {
            var acceptTypes = new Type[]{typeof(string), 
                                        typeof(int?),
                                        typeof(float?),
                                        typeof(DateTime?)};

            return acceptTypes.Contains(property.PropertyType);
        }

        private bool ExcludeProperty(PropertyInfo property)
        {
            var IsNotPrimaryKey = property.Name != "PatientID";
            var AvoidTheDeleteStatus = property.Name != "Status";
            var AvoidEditPatientFrom = property.Name != "PatientFrom";
            var AvoidEditCreateDate = property.Name != "CreateDate";

            return IsNotPrimaryKey
                    && AvoidTheDeleteStatus
                    && AvoidEditPatientFrom
                    && AvoidEditCreateDate;
        }
    }
}