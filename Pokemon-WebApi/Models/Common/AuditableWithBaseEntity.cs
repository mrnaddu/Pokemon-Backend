﻿using Pokemon_WebApi.Models.Interfaces;

namespace Pokemon_WebApi.Models.Common;

public abstract class AuditableWithBaseEntity<T> : BaseEntity<T>, IAuditableEntity
{
    public bool IsDeleted { get; set; } = false;
    public DateTime Created { get; set; } = DateTime.Now;
    public string Author { get; set; } = null!;
    public DateTime Modified { get; set; } = DateTime.Now;
    public string Editor { get; set; } = null!;
}
