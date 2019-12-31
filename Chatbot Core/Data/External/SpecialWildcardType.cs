namespace aytimothy.EIChatbot.Data {
    // Followed based on https://cloud.google.com/dialogflow/docs/reference/system-entities

    public enum SpecialWildcardType {
        None,
        Date,
        DateInterval,
        Time,
        TimeInterval,
        DateTime,
        TimeSpan,
        Number,
        Ordinal,
        Integer,
        NumberSequence,
        FlightNumber,   // Also known as car plates
        AnyUnit,
        AreaUnit,
        CurrencyUnit,
        LengthUnit,
        SpeedUnit,
        VolumeUnit,
        WeightUnit,
        InformationUnit,
        TemperatureUnit,
        DurationUnit,
        AgeUnit,
        CurrencyName,
        UnitName,
        Address,
        StreetAddress = Address,
        ZIPCode,
        Country,
        City,           // Also known as Towns
        District,       // Also known as Suburbs/Localities
        CountryCode,
        Language,
        LanguageCode,
        Airport,
        Coordinate,
        CoordinateShortcode,
        Email,
        PhoneNumber,
        Color,
        URL
    }
}