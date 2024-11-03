﻿namespace DriversManagement.API.DTOs;

public class DriverDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CategoryId { get; set; }
    public int Salary { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? LicenceNumber { get; set; }
}