﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileHis.Data
{
    public class TestQuestionImage
    {
        public TestQuestionImage() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? QuestionID { get; set; }
        [Required]
        public bool Using { get; set; }
        [Required]
        [MaxLength(100)]
        public string FileName { get; set; }

        [ForeignKey("QuestionID")]
        public virtual TestQuestion TestQuestion { get; set; }

    }
}