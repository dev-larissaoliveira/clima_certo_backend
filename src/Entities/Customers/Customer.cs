﻿namespace ClimaTempoWebAPI.Entities.Customers;

public sealed class Customer
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Contact { get; set; } = string.Empty;
}