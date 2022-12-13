namespace StarlightSoftware.Utils;

public static class DateTimeExtensions
{
    /// <summary>
    /// Gets the age in years for the given birthday based on today (using local time)
    /// </summary>
    /// <param name="dateOfBirth">Birthday</param>
    /// <returns>The age in whole years</returns>
    [PublicAPI]
    public static int GetAge(this DateTime dateOfBirth)
    {
        return dateOfBirth.GetAge(DateTime.Today);
    }

    /// <summary>
    /// Gets the age in years for the given birthday based on today (using UTC)
    /// </summary>
    /// <param name="dateOfBirth">Birthday</param>
    /// <returns>The age in whole years</returns>
    [PublicAPI]
    public static int GetAgeUtc(this DateTime dateOfBirth)
    {
        return dateOfBirth.GetAge(DateTime.UtcNow.Date);
    }

    /// <summary>
    /// Gets the age in years for the given birthday on the specified date
    /// </summary>
    /// <param name="dateOfBirth">Birthday</param>
    /// <param name="onDay">The date to calculate the age on</param>
    /// <returns>The age in whole years</returns>
    [PublicAPI]
    public static int GetAge(this DateTime dateOfBirth, DateTime onDay)
    {
        int age = onDay.Year - dateOfBirth.Year;

        if (age > 0)
        {
            age -= Convert.ToInt32(onDay.Date < dateOfBirth.Date.AddYears(age));
        }
        else
        {
            age = 0;
        }

        return age;
    }

    /// <summary>
    /// Gets the age in years for the given birthday based on today (using local time)
    /// </summary>
    /// <param name="dateOfBirth">Birthday</param>
    /// <returns>The age in whole years</returns>
    [PublicAPI]
    public static int GetAge(this DateTimeOffset dateOfBirth)
    {
        return dateOfBirth.Date.GetAge(DateTimeOffset.Now.Date);
    }

    /// <summary>
    /// Gets the age in years for the given birthday based on today (using UTC)
    /// </summary>
    /// <param name="dateOfBirth">Birthday</param>
    /// <returns>The age in whole years</returns>
    [PublicAPI]
    public static int GetAgeUtc(this DateTimeOffset dateOfBirth)
    {
        return dateOfBirth.Date.GetAge(DateTimeOffset.UtcNow.Date);
    }

    /// <summary>
    /// Gets the age in years for the given birthday on the specified date
    /// </summary>
    /// <param name="dateOfBirth">Birthday</param>
    /// <param name="onDay">The date to calculate the age on</param>
    /// <returns>The age in whole years</returns>
    [PublicAPI]
    public static int GetAge(this DateTimeOffset dateOfBirth, DateTimeOffset onDay)
    {
        return dateOfBirth.Date.GetAge(onDay.Date);
    }
}