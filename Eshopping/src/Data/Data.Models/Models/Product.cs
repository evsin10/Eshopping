using Data.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models.Models
{
    public class Product : BaseModel
    {
        private int _minimumCountAlert = 10;
        [StringLength(50, MinimumLength = '4')]
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int CurrentCountInWarehouse { get; set; }
        public int MinimumCountAlert
        {
            get
            {
                return _minimumCountAlert;
            }
            set
            {
                if (value!=_minimumCountAlert)
                {
                    _minimumCountAlert = value;
                }
            }
        }
    }
}
