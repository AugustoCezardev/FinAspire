﻿namespace FinAspire.Core.Common.Extensions;

public static class DateTimeExtension
{
    public static DateTime GetFirtsDay(
        this DateTime date, 
        int? year = null, 
        int? month = null) => new (year ?? date.Year, month ?? date.Month, 1);
    
    public static DateTime GetLastDay(
        this DateTime date, 
        int? year = null, 
        int? month = null) 
        => new (year ?? date.Year, 
            month ?? date.Month, 
            DateTime.DaysInMonth(year ?? date.Year, month ?? date.Month)); 
}