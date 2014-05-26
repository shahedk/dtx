namespace Dtx.Test.BasicOperations
{
    interface IDbTypeConverterTest
    {
        void GetDatabaseDataType();

        void GetDatabaseFriendlyTypeName();

        void GetFrameworkTypeFromFriendlyTypeName();

        void GetFrameworkTypeFromDatabaseTypeName();

        void GetDbTypeFromDatabaseType();
    }
}
