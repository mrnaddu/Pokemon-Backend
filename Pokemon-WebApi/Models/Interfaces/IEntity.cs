﻿namespace Pokemon_WebApi.Models.Interfaces;

public interface IEntity<TId> : IEntity
{
    public TId Id { get; set; }
}

public interface IEntity
{
}
