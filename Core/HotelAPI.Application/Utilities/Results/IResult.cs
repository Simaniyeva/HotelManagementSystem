﻿namespace HotelAPI.Application.Utilities.Results;

public interface IResult
{
    public bool Success { get;  }
    public string Message { get; }
}
