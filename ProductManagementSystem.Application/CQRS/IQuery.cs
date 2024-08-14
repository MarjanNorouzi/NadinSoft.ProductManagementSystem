﻿namespace ProductManagementSystem.Application.CQRS;

public interface IQuery<TResult> where TResult : notnull
{
    Guid Id { get; }
}