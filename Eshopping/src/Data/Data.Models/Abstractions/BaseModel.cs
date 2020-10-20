using Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Abstractions
{
    public abstract class BaseModel : IBaseModel<string>, IEditInfo
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
