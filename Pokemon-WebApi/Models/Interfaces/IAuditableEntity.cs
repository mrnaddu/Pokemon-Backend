﻿namespace Pokemon_WebApi.Models.Interfaces;

public interface IAuditableEntity
{
    bool IsDeleted { get; set; }

    DateTime Created { get; set; }

    string Author { get; set; }

    DateTime Modified { get; set; }

    string Editor { get; set; }
}
