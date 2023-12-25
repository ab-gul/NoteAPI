namespace NoteAPI.Common;

public static class ApiRoutes
{
    private const string Root = "api";
    private const string Version = "v1";
    private const string Base = Root + "/" + Version;

    public static class Notes
    {
        public const string GetAll = Base + "/notes";
        public const string Get = Base + "/notes/{id:Guid}";
        public const string Add = Base + "/notes";
        public const string Update = Base + "/notes/{id:Guid}";
        public const string Delete = Base + "/notes/{id:Guid}";
    }


    public static class Collections
    {
        public const string GetAll = Base + "/collections";
        public const string Get = Base + "/collections/{id:Guid}";
        public const string Add = Base + "/collections";
        public const string Update = Base + "/collections/{id:Guid}";
        public const string Delete = Base + "/collections/{id:Guid}";
    }
}

