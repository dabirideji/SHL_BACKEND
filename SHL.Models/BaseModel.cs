using System;

namespace CSL.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            IsActive = true;
            IsDeleted = false;
            IsSynched = false;
            DateCreated = DateTime.Now;
        }
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSynched { get; set; }
        public long? CreatedById { get; set; }
        public long? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }
    }

    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public bool IsSynched { get; set; }
    }
}
