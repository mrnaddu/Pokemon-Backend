namespace Pokemon_WebApi.Models.Messages;

internal class ResponseMessage
{
    internal static readonly string NameError = "Ouch! Pokemon name already Exist!";
    internal static readonly string UnsuccesfullyUpdated = "Ouch! Pokemon Unsuccessfully Updated";
    internal static readonly string UnsuccesfullyInserted = "Ouch! Pokemon Unsuccessfully Inserted";
    internal static readonly string CouldNotFoundTheData = "Ouch! Could Not Found the Pokemon";
    internal static readonly string SuccessfullyInserted = "Yah! Pokemon Successfully Inserted";
    internal static readonly string SuccessfullyUpdated = "Yah! Pokemon Successfully Updated";
    internal static readonly string SuccessfullyDeleted = "Yah! Pokemon Successfully Deleted";
    internal static readonly string FoundTheData = "Yah! Found the Pokemon";
    internal static readonly string FoundAllData = "Yah! Found All the Pokemon";
}
