using System;

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

    public static class SpecialWildcardTypeOperations {
        public static class FullNames {
            public const string None = "None";
            public const string Date = "Date";
            public const string DateInterval = "Date Interval";
            public const string Time = "Time";
            public const string TimeInterval = "TimeInterval";
            public const string DateTime = "Date/Time";
            public const string TimeSpan = "Time Span";
            public const string Number = "Decimal Number";
            public const string Ordinal = "Ordinal";
            public const string Integer = "Integer Number";
            public const string NumberSequence = "Number Sequence";
            public const string FlightNumber = "Flight Number";
            public const string AnyUnit = "Any Unit";
            public const string AreaUnit = "Area";
            public const string CurrencyUnit = "Currency Amount";
            public const string LengthUnit = "Length";
            public const string SpeedUnit = "Speed";
            public const string VolumeUnit = "Volume";
            public const string WeightUnit = "Weight";
            public const string InformationUnit = "Data Volume";
            public const string TemperatureUnit = "Temperature";
            public const string DurationUnit = "Duration";
            public const string AgeUnit = "Age";
            public const string CurrencyName = "Currency Name";
            public const string UnitName = "Unit Name";
            public const string Address = "Address";
            public const string StreetAddress = "Street Address";
            public const string ZIPCode = "ZIP/Postal Code";
            public const string Country = "Country";
            public const string City = "City";
            public const string District = "District";
            public const string CountryCode = "Country Code";
            public const string Language = "Language";
            public const string LanguageCode = "Language Code";
            public const string Airport = "Airtport Code";
            public const string Coordinate = "Coordinate";
            public const string CoordinateShortcode = "Coordinate Shortcode";
            public const string Email = "Email";
            public const string PhoneNumber = "Phone Number";
            public const string Color = "Color";
            public const string URL = "URL";
        }

        public static class CodeNames {
            public const string None = "S:NONE";
            public const string Date = "S:DATE";
            public const string DateInterval = "S:DTIN";
            public const string Time = "S:TIME";
            public const string TimeInterval = "S:TIIN";
            public const string DateTime = "S:DTTI";
            public const string TimeSpan = "S:TISP";
            public const string Number = "S:NUMB";
            public const string Ordinal = "S:ORDI";
            public const string Integer = "S:INTR";
            public const string NumberSequence = "S:NUSQ";
            public const string FlightNumber = "S:FLNU";
            public const string AnyUnit = "S:ANUN";
            public const string AreaUnit = "S:ARUN";
            public const string CurrencyUnit = "S:CUUN";
            public const string LengthUnit = "S:LGUN";
            public const string SpeedUnit = "S:SPUN";
            public const string VolumeUnit = "S:VLUN";
            public const string WeightUnit = "S:WTUN";
            public const string InformationUnit = "S:INUN";
            public const string TemperatureUnit = "S:TMUN";
            public const string DurationUnit = "S:DRUN";
            public const string AgeUnit = "S:AGUN";
            public const string CurrencyName = "S:CUNM";
            public const string UnitName = "S:UNNM";
            public const string Address = "S:ADDR";
            public const string StreetAddress = "S:STAD";
            public const string ZIPCode = "S:ZIPC";
            public const string Country = "S:COUN";
            public const string City = "S:CITY";
            public const string District = "S:DIST";
            public const string CountryCode = "S:COCO";
            public const string Language = "S:LANG";
            public const string LanguageCode = "S:LACO";
            public const string Airport = "S:AIRP";
            public const string Coordinate = "S:CORD";
            public const string CoordinateShortcode = "S:COSC";
            public const string Email = "S:MAIL";
            public const string PhoneNumber = "S:PHNU";
            public const string Color = "S:COLO";
            public const string URL = "S:WURL";
        }

        public static string WildcardTypeToRawStringIdentifier(SpecialWildcardType type) {
            switch (type) {
                case SpecialWildcardType.None:
                    return CodeNames.None;
                case SpecialWildcardType.Date:
                    return CodeNames.Date;
                case SpecialWildcardType.DateInterval:
                    return CodeNames.DateInterval;
                case SpecialWildcardType.Time:
                    return CodeNames.Time;
                case SpecialWildcardType.TimeInterval:
                    return CodeNames.TimeInterval;
                case SpecialWildcardType.DateTime:
                    return CodeNames.DateTime;
                case SpecialWildcardType.TimeSpan:
                    return CodeNames.TimeSpan;
                case SpecialWildcardType.Number:
                    return CodeNames.Number;
                case SpecialWildcardType.Ordinal:
                    return CodeNames.Ordinal;
                case SpecialWildcardType.Integer:
                    return CodeNames.Integer;
                case SpecialWildcardType.NumberSequence:
                    return CodeNames.NumberSequence;
                case SpecialWildcardType.FlightNumber:
                    return CodeNames.FlightNumber;
                case SpecialWildcardType.AnyUnit:
                    return CodeNames.AnyUnit;
                case SpecialWildcardType.AreaUnit:
                    return CodeNames.AreaUnit;
                case SpecialWildcardType.CurrencyUnit:
                    return CodeNames.CurrencyUnit;
                case SpecialWildcardType.LengthUnit:
                    return CodeNames.LengthUnit;
                case SpecialWildcardType.SpeedUnit:
                    return CodeNames.SpeedUnit;
                case SpecialWildcardType.VolumeUnit:
                    return CodeNames.VolumeUnit;
                case SpecialWildcardType.WeightUnit:
                    return CodeNames.WeightUnit;
                case SpecialWildcardType.InformationUnit:
                    return CodeNames.InformationUnit;
                case SpecialWildcardType.TemperatureUnit:
                    return CodeNames.TemperatureUnit;
                case SpecialWildcardType.DurationUnit:
                    return CodeNames.DurationUnit;
                case SpecialWildcardType.AgeUnit:
                    return CodeNames.AgeUnit;
                case SpecialWildcardType.CurrencyName:
                    return CodeNames.CurrencyName;
                case SpecialWildcardType.UnitName:
                    return CodeNames.UnitName;
                case SpecialWildcardType.Address:
                    return CodeNames.Address;
                case SpecialWildcardType.ZIPCode:
                    return CodeNames.ZIPCode;
                case SpecialWildcardType.Country:
                    return CodeNames.Country;
                case SpecialWildcardType.City:
                    return CodeNames.City;
                case SpecialWildcardType.District:
                    return CodeNames.District;
                case SpecialWildcardType.CountryCode:
                    return CodeNames.CountryCode;
                case SpecialWildcardType.Language:
                    return CodeNames.Language;
                case SpecialWildcardType.LanguageCode:
                    return CodeNames.LanguageCode;
                case SpecialWildcardType.Airport:
                    return CodeNames.Airport;
                case SpecialWildcardType.Coordinate:
                    return CodeNames.Coordinate;
                case SpecialWildcardType.CoordinateShortcode:
                    return CodeNames.CoordinateShortcode;
                case SpecialWildcardType.Email:
                    return CodeNames.Email;
                case SpecialWildcardType.PhoneNumber:
                    return CodeNames.PhoneNumber;
                case SpecialWildcardType.Color:
                    return CodeNames.Color;
                case SpecialWildcardType.URL:
                    return CodeNames.URL;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static SpecialWildcardType RawStringIdentifierToWildcardType(string type) {
            switch (type.ToUpper()) {
                case CodeNames.None:
                    return SpecialWildcardType.None;
                case CodeNames.Date:
                    return SpecialWildcardType.Date;
                case CodeNames.DateInterval:
                    return SpecialWildcardType.DateInterval;
                case CodeNames.Time:
                    return SpecialWildcardType.Time;
                case CodeNames.TimeInterval:
                    return SpecialWildcardType.TimeInterval;
                case CodeNames.DateTime:
                    return SpecialWildcardType.DateTime;
                case CodeNames.TimeSpan:
                    return SpecialWildcardType.TimeSpan;
                case CodeNames.Number:
                    return SpecialWildcardType.Number;
                case CodeNames.Integer:
                    return SpecialWildcardType.Integer;
                case CodeNames.Ordinal:
                    return SpecialWildcardType.Ordinal;
                case CodeNames.NumberSequence:
                    return SpecialWildcardType.NumberSequence;
                case CodeNames.FlightNumber:
                    return SpecialWildcardType.FlightNumber;
                case CodeNames.AnyUnit:
                    return SpecialWildcardType.AnyUnit;
                case CodeNames.AreaUnit:
                    return SpecialWildcardType.AreaUnit;
                case CodeNames.CurrencyUnit:
                    return SpecialWildcardType.CurrencyUnit;
                case CodeNames.LengthUnit:
                    return SpecialWildcardType.LengthUnit;
                case CodeNames.SpeedUnit:
                    return SpecialWildcardType.SpeedUnit;
                case CodeNames.VolumeUnit:
                    return SpecialWildcardType.VolumeUnit;
                case CodeNames.WeightUnit:
                    return SpecialWildcardType.WeightUnit;
                case CodeNames.InformationUnit:
                    return SpecialWildcardType.InformationUnit;
                case CodeNames.TemperatureUnit:
                    return SpecialWildcardType.TemperatureUnit;
                case CodeNames.DurationUnit:
                    return SpecialWildcardType.DurationUnit;
                case CodeNames.AgeUnit:
                    return SpecialWildcardType.AgeUnit;
                case CodeNames.CurrencyName:
                    return SpecialWildcardType.CurrencyName;
                case CodeNames.UnitName:
                    return SpecialWildcardType.UnitName;
                case CodeNames.Address:
                    return SpecialWildcardType.Address;
                case CodeNames.ZIPCode:
                    return SpecialWildcardType.ZIPCode;
                case CodeNames.Country:
                    return SpecialWildcardType.Country;
                case CodeNames.City:
                    return SpecialWildcardType.City;
                case CodeNames.District:
                    return SpecialWildcardType.District;
                case CodeNames.CountryCode:
                    return SpecialWildcardType.CountryCode;
                case CodeNames.Language:
                    return SpecialWildcardType.Language;
                case CodeNames.LanguageCode:
                    return SpecialWildcardType.LanguageCode;
                case CodeNames.Airport:
                    return SpecialWildcardType.Airport;
                case CodeNames.Coordinate:
                    return SpecialWildcardType.Coordinate;
                case CodeNames.CoordinateShortcode:
                    return SpecialWildcardType.CoordinateShortcode;
                case CodeNames.Email:
                    return SpecialWildcardType.Email;
                case CodeNames.PhoneNumber:
                    return SpecialWildcardType.PhoneNumber;
                case CodeNames.Color:
                    return SpecialWildcardType.Color;
                case CodeNames.URL:
                    return SpecialWildcardType.URL;
                default:
                    return SpecialWildcardType.None;
            }
        }
    }
}